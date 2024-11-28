using BikeRental.Domain.Model;

namespace BikeRental.Infrastructure.Repository.Mock;

public class CustomerRepositoryMock
{
    private static readonly List<Customer> _customers = new List<Customer>();

    public Task<List<Customer>> GetAsList()
    {
        return Task.FromResult(_customers.ToList());
    }

    public Task<Customer?> GetByKey(int key)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == key);
        return Task.FromResult(customer);
    }

    public Task Add(Customer newRecord)
    {
        _customers.Add(newRecord);
        return Task.CompletedTask;
    }

    public Task Delete(int key)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == key);
        if (customer != null)
        {
            _customers.Remove(customer);
        }
        return Task.CompletedTask;
    }

    public Task Update(int key, Customer newValue)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == key);
        if (customer != null)
        {
            customer.FullName = newValue.FullName;
            customer.BirthDate = newValue.BirthDate;
            customer.PhoneNumber = newValue.PhoneNumber;
        }
        return Task.CompletedTask;
    }
}
