using BikeRental.Contracts;
using BikeRental.Contracts.Customer;
using BikeRental.Contracts.Rent;
using BikeRental.Domain.Enums;
using BikeRental.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace BikeRental.RestApi.Host.Controllers;

/// <summary>
/// Контроллер для выполнения аналитических запросов
/// </summary>
/// <param name="bikeService">Сервис Bike</param>
/// <param name="customerService">Сервис Customer</param>
/// <param name="rentService">Сервис Rent</param>
[Route("api/[controller]")]
[ApiController]
public class AnalyticalController(
    ICrudService<Bike, Bike, int> bikeService,
    ICrudService<CustomerDto, CustomerCreateUpdateDto, int> customerService,
    ICrudService<RentDto, RentCreateUpdateDto, int> rentService)
    : ControllerBase
{
    private readonly ICrudService<CustomerDto, CustomerCreateUpdateDto, int> _customerService = customerService;

    /// <summary>
    /// Вывести информацию обо всех спортивных велосипедах.
    /// </summary>
    [HttpGet("sport-bikes")]
    public async Task<IActionResult> GetAllSportBikes(CancellationToken cancellationToken)
    {
        var bikes = await bikeService.GetList(cancellationToken);
        var sportBikes = bikes.Where(b => b.Type == BikeType.Sport).ToList();
        return Ok(sportBikes);
    }

    /// <summary>
    /// Вывести информацию обо всех клиентах, которые брали в аренду горные велосипеды, упорядочить по ФИО.
    /// </summary>
    [HttpGet("customers-with-mountain-bikes")]
    public async Task<IActionResult> GetCustomersWithMountainBikesSortedByName(CancellationToken cancellationToken)
    {
        var rents = await rentService.GetList(cancellationToken);
        var bikes = await bikeService.GetList(cancellationToken);
        var bikeDictionary = bikes.ToDictionary(b => b.SerialNumber);
        var mountainBikeRents = rents
            .Where(r => r.BikeId != null && bikeDictionary.ContainsKey(r.BikeId.Value) &&
                        bikeDictionary[r.BikeId.Value].Type == BikeType.Mountain)
            .Select(r => r.CustomerId)
            .Distinct()
            .ToList();

        var customers = new List<CustomerDto>();
        foreach (var customerId in mountainBikeRents.Where(c => c != null))
        {
            var customer = await _customerService.GetById(customerId!.Value, cancellationToken);
            if (customer != null)
            {
                customers.Add(customer);
            }
        }

        var sortedCustomers = customers.OrderBy(c => c.FullName).ToList();

        return Ok(sortedCustomers);
    }

    /// <summary>
    /// Вывести суммарное время аренды велосипедов каждого типа.
    /// </summary>
    [HttpGet("rental-time-by-bike-type")]
    public async Task<IActionResult> GetTotalRentalTimeByBikeType(CancellationToken cancellationToken)
    {
        var rents = await rentService.GetList(cancellationToken);
        var bikes = await bikeService.GetList(cancellationToken);
        var bikeTypeDictionary = bikes.ToDictionary(b => b.SerialNumber, b => b.Type);

        var totalRentalTimeByType = rents
            .Where(r => r.BikeId != null)
            .GroupBy(r => bikeTypeDictionary[r.BikeId!.Value])
            .Select(g => new
            {
                BikeType = g.Key,
                TotalTime = g.Sum(r
                    => r is { End: not null, Start: not null } ? (r.End!.Value - r.Start!.Value).TotalHours : 0)
            })
            .ToList();

        return Ok(totalRentalTimeByType);
    }

    /// <summary>
    /// Вывести информацию о клиентах, бравших велосипеды на прокат больше всего раз.
    /// </summary>
    [HttpGet("customers-with-most-rentals")]
    public async Task<IActionResult> GetCustomersWithMostRentals(CancellationToken cancellationToken)
    {
        var rents = await rentService.GetList(cancellationToken);
        var customers = await customerService.GetList(cancellationToken);
        var customerDictionary = customers.ToDictionary(c => c.Id);
        var maxRentCount = rents
            .GroupBy(r => r.CustomerId)
            .OrderByDescending(g => g.Count())
            .First()
            .Count();

        var topCustomerIds = rents
            .GroupBy(r => r.CustomerId)
            .Where(g => g.Count() == maxRentCount)
            .Select(g => g.Key)
            .ToList();

        var topCustomers = topCustomerIds
            .Where(id => id.HasValue)
            .Select(customerId => customerDictionary[customerId!.Value])
            .ToList();

        return Ok(topCustomers);
    }

    /// <summary>
    /// Вывести информацию о топ 5 наиболее часто арендуемых велосипедов.
    /// </summary>
    [HttpGet("top-5-most-rented-bikes")]
    public async Task<IActionResult> GetTop5MostRentedBikes(CancellationToken cancellationToken)
    {
        var rents = await rentService.GetList(cancellationToken);
        var bikes = await bikeService.GetList(cancellationToken);
        var bikeDictionary = bikes.ToDictionary(b => b.SerialNumber);

        var topBikes = rents
            .GroupBy(r => r.BikeId)
            .OrderByDescending(g => g.Count())
            .Take(5)
            .Select(g => bikeDictionary[g.Key!.Value])
            .ToList();

        return Ok(topBikes);
    }

    /// <summary>
    /// Вывести информацию о минимальном, максимальном и среднем времени аренды велосипедов.
    /// </summary>
    [HttpGet("min-max-average-rental-time")]
    public async Task<IActionResult> GetMinMaxAverageRentalTime(CancellationToken cancellationToken)
    {
        var rents = await rentService.GetList(cancellationToken);
        var rentalTimes = rents
            .Select(r => r is { End: not null, Start: not null } ? (r.End.Value - r.Start.Value).TotalHours : 0)
            .ToList();

        var minTime = rentalTimes.Min();
        var maxTime = rentalTimes.Max();
        var averageTime = rentalTimes.Average();

        var result = new
        {
            MinTime = minTime,
            MaxTime = maxTime,
            AverageTime = averageTime
        };

        return Ok(result);
    }
}