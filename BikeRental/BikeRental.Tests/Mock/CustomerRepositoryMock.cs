using BikeRental.Domain.Interfaces;
using BikeRental.Domain.Model;
using BikeRental.Infrastructure.DataSeed;

namespace BikeRental.Tests.Mock;

public class CustomerRepositoryMock : IRepository<Customer, int>
{
    private static readonly List<Customer> Customers = BikeRentalSeeder.GetCustomers();

    public Task<List<Customer>> GetAsList()
    {
        return Task.FromResult(Customers.ToList());
    }

    public Task<Customer?> GetByKey(int key)
    {
        var customer = Customers.FirstOrDefault(c => c.Id == key);
        return Task.FromResult(customer);
    }

    public Task Add(Customer newRecord)
    {
        newRecord.Id = Customers.Max(c => c.Id) + 1;
        Customers.Add(newRecord);
        return Task.CompletedTask;
    }

    public Task Delete(int key)
    {
        var customer = Customers.FirstOrDefault(c => c.Id == key);
        if (customer == null) return Task.CompletedTask;
        Customers.Remove(customer);
        return Task.CompletedTask;
    }

    public Task Update(int key, Customer newValue)
    {
        var customer = Customers.FirstOrDefault(c => c.Id == key);
        if (customer == null) return Task.CompletedTask;
        customer.FullName = newValue.FullName;
        customer.BirthDate = newValue.BirthDate;
        customer.PhoneNumber = newValue.PhoneNumber;
        return Task.CompletedTask;
    }
}
