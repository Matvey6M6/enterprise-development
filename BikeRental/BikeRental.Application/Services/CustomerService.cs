using AutoMapper;
using BikeRental.Contracts;
using BikeRental.Contracts.Customer;
using BikeRental.Domain.Interfaces;
using BikeRental.Domain.Model;

namespace BikeRental.Application.Services;

public class CustomerService(IRepository<Customer, int> CustomerRepository, IMapper Mapper): ICrudService<CustomerDto, CustomerCreateUpdateDto, int>
{
    public async Task<CustomerDto> Create(CustomerCreateUpdateDto newDto, CancellationToken cancellationToken)
    {
        var customer = Mapper.Map<Customer>(newDto);
        await CustomerRepository.Add(customer);
        var newbie = await CustomerRepository.GetByKey(customer.Id);
        return Mapper.Map<CustomerDto>(newbie);
    }

    public async Task<CustomerDto> Update(int key, CustomerCreateUpdateDto newDto, CancellationToken cancellationToken)
    {
        var customer = Mapper.Map<Customer>(newDto);
        await CustomerRepository.Update(key, customer);
        var newbie = await CustomerRepository.GetByKey(key);
        return Mapper.Map<CustomerDto>(newbie);
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        var customer = await CustomerRepository.GetByKey(id);
        if (customer == null)
            return false;

        await CustomerRepository.Delete(id);
        return true;
    }

    public async Task<IList<CustomerDto>> GetList(CancellationToken cancellationToken) =>
        (await CustomerRepository.GetAsList()).Select(Mapper.Map<CustomerDto>).ToList();

    public async Task<CustomerDto?> GetById(int id, CancellationToken cancellationToken) =>
        Mapper.Map<CustomerDto?>(await CustomerRepository.GetByKey(id));
}
