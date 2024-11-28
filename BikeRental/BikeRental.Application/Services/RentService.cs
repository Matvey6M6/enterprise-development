using BikeRental.Contracts;
using BikeRental.Contracts.Rent;
using BikeRental.Domain.Model;

namespace BikeRental.Application.Services;

public class RentService(IRepository<Rent, int> rentRepository): ICrudService<RentDto, RentCreateUpdateDto, int>
{
    public async Task<RentDto> Create(RentCreateUpdateDto newDto, CancellationToken cancellationToken)
    {
        var rent = new Rent
        {
            BikeId = newDto.BikeId ?? throw new ArgumentException("Аренда не может существовать без конкретного велосипеда."),
            CustomerId = newDto.CustomerId ?? throw new ArgumentException("Аренда не может существовать без конкретного арендатора."),
            Start = newDto.Start ?? DateTime.Now,
            End = newDto.End ?? DateTime.Now.AddHours(1)
        };

        await rentRepository.Add(rent);

        return new RentDto
        {
            Id = rent.Id,
            BikeId = rent.BikeId,
            CustomerId = rent.CustomerId,
            Start = rent.Start,
            End = rent.End
        };
    }

    public async Task<RentDto> Update(int key, RentCreateUpdateDto newDto, CancellationToken cancellationToken)
    {
        var rent = await rentRepository.GetByKey(key);
        if (rent == null)
            throw new KeyNotFoundException("Rent not found.");

        rent.BikeId = newDto.BikeId ?? throw new ArgumentException("Аренда не может существовать без конкретного велосипеда.");
        rent.CustomerId = newDto.CustomerId ?? throw new ArgumentException("Аренда не может существовать без конкретного арендатора.");
        rent.Start = newDto.Start ?? DateTime.Now;
        rent.End = newDto.End ?? DateTime.Now.AddHours(1);

        await rentRepository.Update(key, rent);

        return new RentDto
        {
            Id = rent.Id,
            BikeId = rent.BikeId,
            CustomerId = rent.CustomerId,
            Start = rent.Start,
            End = rent.End
        };
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        var rent = await rentRepository.GetByKey(id);
        if (rent == null)
            return false;

        await rentRepository.Delete(id);
        return true;
    }

    public async Task<IList<RentDto>> GetList(CancellationToken cancellationToken)
    {
        var rents = await rentRepository.GetAsList();
        return rents.Select(rent => new RentDto
        {
            Id = rent.Id,
            BikeId = rent.BikeId,
            CustomerId = rent.CustomerId,
            Start = rent.Start,
            End = rent.End
        }).ToList();
    }

    public async Task<RentDto?> GetById(int id, CancellationToken cancellationToken)
    {
        var rent = await rentRepository.GetByKey(id);
        if (rent == null)
            return null;

        return new RentDto
        {
            Id = rent.Id,
            BikeId = rent.BikeId,
            CustomerId = rent.CustomerId,
            Start = rent.Start,
            End = rent.End
        };
    }
}
