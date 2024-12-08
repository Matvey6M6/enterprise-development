using AutoMapper;
using BikeRental.Contracts;
using BikeRental.Contracts.Bike;
using BikeRental.Domain.Interfaces;
using BikeRental.Domain.Model;

namespace BikeRental.Application.Services;

public class BikeService(IRepository<Bike, int> bikeRepository, IMapper mapper) : ICrudService<BikeDto, BikeCreateUpdateDto, int>
{
    public async Task<BikeDto> Create(BikeCreateUpdateDto newDto, CancellationToken cancellationToken)
    {
        var bike = mapper.Map<Bike>(newDto);
        await bikeRepository.Add(bike);
        return mapper.Map<BikeDto>(bike);
    }

    public async Task<BikeDto> Update(int key, BikeCreateUpdateDto newDto, CancellationToken cancellationToken)
    {
        var bike = await bikeRepository.GetByKey(key);

        if (bike == null)
            throw new KeyNotFoundException("Bike not found.");

        var mappedModel = mapper.Map<Bike>(newDto);

        bike = mappedModel;

        await bikeRepository.Update(key, bike);
        return mapper.Map<BikeDto>(bike);
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        var bike = await bikeRepository.GetByKey(id);
        if (bike == null)
            return false;

        await bikeRepository.Delete(id);
        return true;
    }

    public async Task<IList<BikeDto>> GetList(CancellationToken cancellationToken)
    {
        var bikes = await bikeRepository.GetAsList();
        return bikes.Select(bike => mapper.Map<BikeDto>(bike)).ToList();
    }

    public async Task<BikeDto?> GetById(int id, CancellationToken cancellationToken)
    {
        var bike = await bikeRepository.GetByKey(id);
        if (bike == null)
            return null;

        return mapper.Map<BikeDto>(bike);
    }
}