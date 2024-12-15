using BikeRental.Domain.Interfaces;
using BikeRental.Domain.Model;
using BikeRental.Infrastructure.DatabaseConfiguration;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.Infrastructure.Repository;

public class CustomerRepository(BikeRentMySqlContext DbContext) : IRepository<Customer, int>
{
    public async Task<List<Customer>> GetAsList() =>
        await DbContext.Customesrs.ToListAsync();

    public async Task<Customer?> GetByKey(int key) =>
        await DbContext.Customesrs.FirstOrDefaultAsync(c => c.Id == key);

    public async Task Add(Customer newRecord)
    {
        await DbContext.Customesrs.AddAsync(newRecord);
        await DbContext.SaveChangesAsync();
    }

    public async Task Delete(int key)
    {
        var customer = await GetByKey(key);
        if (customer == null) return;
        DbContext.Customesrs.Remove(customer);
        await DbContext.SaveChangesAsync();
    }

    public async Task Update(int key, Customer newValue)
    {
        var customer = await GetByKey(key);
        if (customer == null) return;
        customer.FullName = newValue.FullName;
        customer.BirthDate = newValue.BirthDate;
        customer.PhoneNumber = newValue.PhoneNumber;
        DbContext.Customesrs.Update(customer);
        await DbContext.SaveChangesAsync();
    }
}
