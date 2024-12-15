using AutoMapper;
using BikeRental.Contracts;
using BikeRental.Contracts.Rent;
using BikeRental.Domain.Interfaces;
using BikeRental.Domain.Model;

namespace BikeRental.Application.Services;

public class RentService(IRepository<Rent, int> RentRepository, IMapper Mapper): ICrudService<RentDto, RentCreateUpdateDto, int>
{
    public async Task<RentDto> Create(RentCreateUpdateDto newDto, CancellationToken cancellationToken)
    {
        var rent = Mapper.Map<Rent>(newDto);
        await RentRepository.Add(rent);
        return Mapper.Map<RentDto>(await RentRepository.GetByKey(rent.Id));
    }

    public async Task<RentDto> Update(int key, RentCreateUpdateDto newDto, CancellationToken cancellationToken)
    {
        var rent = Mapper.Map<Rent>(newDto);
        await RentRepository.Update(key, rent);
        return Mapper.Map<RentDto>(await RentRepository.GetByKey(rent.Id));
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        var rent = await RentRepository.GetByKey(id);
        if (rent == null)
            return false;

        await RentRepository.Delete(id);
        return true;
    }

    public async Task<IList<RentDto>> GetList(CancellationToken cancellationToken) =>
        (await RentRepository.GetAsList()).Select(Mapper.Map<RentDto>).ToList();

    public async Task<RentDto?> GetById(int id, CancellationToken cancellationToken) =>
        Mapper.Map<RentDto?>(await RentRepository.GetByKey(id));
}
