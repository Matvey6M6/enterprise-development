using BikeRental.Domain.Enums;
using BikeRental.Domain.Model;
using BikeRental.Tests.Fixture;

namespace BikeRent.Tests;

public class AnalyticalQueriesTests(TestFixture fixture) : IClassFixture<TestFixture>
{
    private List<Bike> _bikes => fixture.Bikes;
    private List<Rent> _rents => fixture.Rents;
    private List<Customer> _customers => fixture.Customers;

    /// <summary>
    /// ������� ���������� ��� ���� ���������� �����������.
    /// </summary>
    [Fact]
    public void GetAllSportBikes()
    {
        var sportBikes = _bikes.Where(b => b.Type == BikeType.Sport).ToList();

        Assert.NotEmpty(sportBikes);
        Assert.All(sportBikes, bike => Assert.Equal(BikeType.Sport, bike.Type));
    }

    /// <summary>
    /// ������� ���������� ��� ���� ��������, ������� ����� � ������ ������ ����������, ����������� �� ���.
    /// </summary>
    [Fact]
    public void GetCustomersWithMountainBikesSortedByName()
    {
        var mountainBikeCustomers = _rents
            .Where(r => r.Bike.Type == BikeType.Mountain)
            .Select(r => r.Customer)
            .Distinct()
            .OrderBy(c => c.FullName)
            .ToList();

        Assert.NotEmpty(mountainBikeCustomers);
        Assert.True(mountainBikeCustomers.SequenceEqual(mountainBikeCustomers.OrderBy(c => c.FullName)));
    }

    /// <summary>
    /// ������� ��������� ����� ������ ����������� ������� ����.
    /// </summary>
    [Fact]
    public void GetTotalRentalTimeByBikeType()
    {
        var totalRentalTimeByType = _rents
            .GroupBy(r => r.Bike.Type)
            .Select(g => new
            {
                BikeType = g.Key,
                TotalTime = g.Sum(r => (r.End - r.Start).TotalHours)
            })
            .ToList();

        Assert.NotEmpty(totalRentalTimeByType);
        Assert.All(totalRentalTimeByType, entry => Assert.True(entry.TotalTime > 0));
    }

    /// <summary>
    /// ������� ���������� � ��������, ������� ���������� �� ������ ������ ����� ���.
    /// </summary>
    [Fact]
    public void GetCustomersWithMostRentals()
    {
        var maxRentCount = _rents
            .GroupBy(r => r.Customer)
            .OrderByDescending(g => g.Count())
            .First().Count();

        var topCustomers = _rents
            .GroupBy(r => r.Customer)
            .Where(g => g.Count() == maxRentCount)
            .Select(g => g.Key)
            .ToList();

        Assert.NotEmpty(topCustomers);
    }

    /// <summary>
    /// ������� ���������� � ��� 5 �������� ����� ���������� �����������.
    /// </summary>
    [Fact]
    public void GetTop5MostRentedBikes()
    {
        var topBikes = _rents
            .GroupBy(r => r.Bike)
            .OrderByDescending(g => g.Count())
            .Take(5)
            .Select(g => g.Key)
            .ToList();

        Assert.NotEmpty(topBikes);
        Assert.True(topBikes.Count <= 5);
    }

    /// <summary>
    /// ������� ���������� � �����������, ������������ � ������� ������� ������ �����������.
    /// </summary>
    [Fact]
    public void GetMinMaxAverageRentalTime()
    {
        var rentalTimes = _rents
            .Select(r => (r.End - r.Start).TotalHours)
            .ToList();

        var minTime = rentalTimes.Min();
        var maxTime = rentalTimes.Max();
        var averageTime = rentalTimes.Average();

        Assert.True(minTime > 0);
        Assert.True(maxTime >= minTime);
        Assert.True(averageTime >= minTime && averageTime <= maxTime);
    }
}
