using BikeRental.Contracts.Customer;
using BikeRental.Domain.Model;

namespace BikeRental.Application.Services;

public class CustomerService
{
    private readonly IRepository<Customer, int> _customerRepository;

    public CustomerService(IRepository<Customer, int> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDto> Create(CustomerCreateUpdateDto newDto, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            Id = 0,
            FullName = newDto.FullName,
            BirthDate = newDto.BirthDate,
            PhoneNumber = newDto.PhoneNumber
        };

        await _customerRepository.Add(customer);
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
        var customer = await _customerRepository.GetByKey(key);

        if (customer == null)
            throw new KeyNotFoundException("Customer not found.");

        customer.FullName = newDto.FullName;
        customer.BirthDate = newDto.BirthDate;
        customer.PhoneNumber = newDto.PhoneNumber;

        await _customerRepository.Update(key, customer);
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
        var customer = await _customerRepository.GetByKey(id);
        if (customer == null)
            return false;

        await _customerRepository.Delete(id);
        return true;
    }

    public async Task<IList<CustomerDto>> GetList(CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetAsList();
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
        var customer = await _customerRepository.GetByKey(id);
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
