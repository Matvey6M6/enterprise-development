using BikeRental.Contracts;
using BikeRental.Contracts.Customer;
using BikeRental.Domain.Interfaces;
using BikeRental.Domain.Model;

namespace BikeRental.Application.Services;

public class CustomerService(IRepository<Customer, int> customerRepository): ICrudService<CustomerDto, CustomerCreateUpdateDto, int>
{
    public async Task<CustomerDto> Create(CustomerCreateUpdateDto newDto, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            Id = 0,
            FullName = newDto.FullName,
            BirthDate = newDto.BirthDate,
            PhoneNumber = newDto.PhoneNumber
        };

        await customerRepository.Add(customer);
        return new CustomerDto
        {
            Id = customer.Id,
            FullName = customer.FullName,
            BirthDate = customer.BirthDate,
            PhoneNumber = customer.PhoneNumber
        };
    }

    public async Task<CustomerDto> Update(int key, CustomerCreateUpdateDto newDto, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetByKey(key);

        if (customer == null)
            throw new KeyNotFoundException("Customer not found.");

        customer.FullName = newDto.FullName;
        customer.BirthDate = newDto.BirthDate;
        customer.PhoneNumber = newDto.PhoneNumber;

        await customerRepository.Update(key, customer);
        return new CustomerDto
        {
            Id = customer.Id,
            FullName = customer.FullName,
            BirthDate = customer.BirthDate,
            PhoneNumber = customer.PhoneNumber
        };
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetByKey(id);
        if (customer == null)
            return false;

        await customerRepository.Delete(id);
        return true;
    }

    public async Task<IList<CustomerDto>> GetList(CancellationToken cancellationToken)
    {
        var customers = await customerRepository.GetAsList();
        return customers.Select(c => new CustomerDto
        {
            Id = c.Id,
            FullName = c.FullName,
            BirthDate = c.BirthDate,
            PhoneNumber = c.PhoneNumber
        }).ToList();
    }

    public async Task<CustomerDto?> GetById(int id, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetByKey(id);
        if (customer == null)
            return null;

        return new CustomerDto
        {
            Id = customer.Id,
            FullName = customer.FullName,
            BirthDate = customer.BirthDate,
            PhoneNumber = customer.PhoneNumber
        };
    }
}
