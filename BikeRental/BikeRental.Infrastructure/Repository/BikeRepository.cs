using BikeRental.Domain.Interfaces;
using BikeRental.Domain.Model;
using BikeRental.Infrastructure.DatabaseConfiguration;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.Infrastructure.Repository;

public class BikeRepository(BikeRentMySqlContext DbContext) : IRepository<Bike, int>
{
    public async Task<List<Bike>> GetAsList() =>
        await DbContext.Bikes.ToListAsync();

    public async Task<Bike?> GetByKey(int key) =>
        await DbContext.Bikes.FirstOrDefaultAsync(b => b.SerialNumber == key);

    public async Task Add(Bike newRecord)
    {
        if (await GetByKey(newRecord.SerialNumber) != null)
        {
            throw new ArgumentException("Серийный номер занят.");
        }

        await DbContext.Bikes.AddAsync(newRecord);
        await DbContext.SaveChangesAsync();
    }

    public async Task Delete(int key)
    {
        var bike = await GetByKey(key);
        if (bike == null) return;
        DbContext.Bikes.Remove(bike);
        await DbContext.SaveChangesAsync();
    }

    public async Task Update(int key, Bike newValue)
    {
        var bike = await GetByKey(key);
        if (bike == null) return;
        bike.Type = newValue.Type;
        bike.Model = newValue.Model;
        bike.Color = newValue.Color;
        bike.CostPerPrice = newValue.CostPerPrice;
        DbContext.Bikes.Update(bike);
        await DbContext.SaveChangesAsync();
    }
}