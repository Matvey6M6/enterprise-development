using BikeRental.Domain.Interfaces;
using BikeRental.Domain.Model;
using BikeRental.Infrastructure.DataSeed;

namespace BikeRental.Tests.Mock;

public class BikeRepositoryMock : IRepository<Bike, int>
{
    private static readonly List<Bike> Bikes = BikeRentalSeeder.GetBikes();

    public Task<List<Bike>> GetAsList()
    {
        return Task.FromResult(Bikes.ToList());
    }

    public Task<Bike?> GetByKey(int key)
    {
        var bike = Bikes.FirstOrDefault(b => b.SerialNumber == key);
        return Task.FromResult(bike);
    }

    public Task Add(Bike newRecord)
    {
        if (Bikes.Any(b => b.SerialNumber == newRecord.SerialNumber))
        {
            throw new ArgumentException("Серийный номер занят.");
        }

        Bikes.Add(newRecord);
        return Task.CompletedTask;
    }

    public Task Delete(int key)
    {
        var bike = Bikes.FirstOrDefault(b => b.SerialNumber == key);
        if (bike != null)
        {
            Bikes.Remove(bike);
        }
        return Task.CompletedTask;
    }

    public Task Update(int key, Bike newValue)
    {
        var bike = Bikes.FirstOrDefault(b => b.SerialNumber == key);
        if (bike == null) return Task.CompletedTask;
        bike.Type = newValue.Type;
        bike.Model = newValue.Model;
        bike.Color = newValue.Color;
        bike.CostPerPrice = newValue.CostPerPrice;
        return Task.CompletedTask;
    }
}
