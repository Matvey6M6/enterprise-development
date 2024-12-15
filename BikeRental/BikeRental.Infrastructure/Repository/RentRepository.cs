using BikeRental.Domain.Interfaces;
using BikeRental.Domain.Model;
using BikeRental.Infrastructure.DatabaseConfiguration;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.Infrastructure.Repository;

public class RentRepository(BikeRentMySqlContext DbContext) : IRepository<Rent, int>
{
    public async Task<List<Rent>> GetAsList() =>
        await DbContext.Rents.ToListAsync();

    public async Task<Rent?> GetByKey(int key) =>
        await DbContext.Rents.FirstOrDefaultAsync(r => r.Id == key);

    public async Task Add(Rent newRecord)
    {
        await DbContext.Rents.AddAsync(newRecord);
        await DbContext.SaveChangesAsync();
    }

    public async Task Delete(int key)
    {
        var rent = await GetByKey(key);
        if (rent == null) return;
        DbContext.Rents.Remove(rent);
        await DbContext.SaveChangesAsync();
    }

    public async Task Update(int key, Rent newValue)
    {
        var rent = await GetByKey(key);
        if (rent == null) return;
        rent.Bike = newValue.Bike;
        rent.Customer = newValue.Customer;
        rent.Start = newValue.Start;
        rent.End = newValue.End;
        DbContext.Rents.Update(rent);
        await DbContext.SaveChangesAsync();
    }
}
