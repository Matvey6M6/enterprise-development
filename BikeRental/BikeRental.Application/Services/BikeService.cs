using BikeRental.Contracts;
using BikeRental.Domain.Model;

namespace BikeRental.Application.Services;

public class BikeService : ICrudService<Bike, Bike, int>
{
    private readonly IRepository<Bike, int> _bikeRepository;

    public BikeService(IRepository<Bike, int> bikeRepository)
    {
        _bikeRepository = bikeRepository;
    }

    public async Task<Bike> Create(Bike newDto, CancellationToken cancellationToken)
    {
        var bike = new Bike
        {
            SerialNumber = newDto.SerialNumber,
            Type = newDto.Type,
            Model = newDto.Model,
            Color = newDto.Color,
            CostPerPrice = newDto.CostPerPrice
        };

        await _bikeRepository.Add(bike);
        return new Bike
        {
            SerialNumber = bike.SerialNumber,
            Type = bike.Type,
            Model = bike.Model,
            Color = bike.Color,
            CostPerPrice = bike.CostPerPrice
        };
    }

    public async Task<Bike> Update(int key, Bike newDto, CancellationToken cancellationToken)
    {
        var bike = await _bikeRepository.GetByKey(key);

        if (bike == null)
            throw new KeyNotFoundException("Bike not found.");

        bike.Type = newDto.Type;
        bike.Model = newDto.Model;
        bike.Color = newDto.Color;
        bike.CostPerPrice = newDto.CostPerPrice;

        await _bikeRepository.Update(key, bike);
        return new Bike
        {
            SerialNumber = bike.SerialNumber,
            Type = bike.Type,
            Model = bike.Model,
            Color = bike.Color,
            CostPerPrice = bike.CostPerPrice
        };
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        var bike = await _bikeRepository.GetByKey(id);
        if (bike == null)
            return false;

        await _bikeRepository.Delete(id);
        return true;
    }

    public async Task<IList<Bike>> GetList(CancellationToken cancellationToken)
    {
        var bikes = await _bikeRepository.GetAsList();
        return bikes.Select(bike => new Bike
        {
            SerialNumber = bike.SerialNumber,
            Type = bike.Type,
            Model = bike.Model,
            Color = bike.Color,
            CostPerPrice = bike.CostPerPrice
        }).ToList();
    }

    public async Task<Bike?> GetById(int id, CancellationToken cancellationToken)
    {
        var bike = await _bikeRepository.GetByKey(id);
        if (bike == null)
            return null;

        return new Bike
        {
            SerialNumber = bike.SerialNumber,
            Type = bike.Type,
            Model = bike.Model,
            Color = bike.Color,
            CostPerPrice = bike.CostPerPrice
        };
    }
}