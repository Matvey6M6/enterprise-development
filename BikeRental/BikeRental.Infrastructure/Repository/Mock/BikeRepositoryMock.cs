using BikeRental.Domain.Model;
using BikeRental.Infrastructure.DataSeed;

namespace BikeRental.Infrastructure.Repository.Mock;

public class BikeRepository : IRepository<Bike, int>
{
    private static readonly List<Bike> _bikes = BikeRentalSeeder.GetBikes();

    public Task<List<Bike>> GetAsList()
    {
        return Task.FromResult(_bikes.ToList());
    }

    public Task<Bike?> GetByKey(int key)
    {
        var bike = _bikes.FirstOrDefault(b => b.SerialNumber == key);
        return Task.FromResult(bike);
    }

    public Task Add(Bike newRecord)
    {
        _bikes.Add(newRecord);
        return Task.CompletedTask;
    }

    public Task Delete(int key)
    {
        var bike = _bikes.FirstOrDefault(b => b.SerialNumber == key);
        if (bike != null)
        {
            _bikes.Remove(bike);
        }
        return Task.CompletedTask;
    }

    public Task Update(int key, Bike newValue)
    {
        var bike = _bikes.FirstOrDefault(b => b.SerialNumber == key);
        if (bike != null)
        {
            bike.Type = newValue.Type;
            bike.Model = newValue.Model;
            bike.Color = newValue.Color;
            bike.CostPerPrice = newValue.CostPerPrice;
        }
        return Task.CompletedTask;
    }
}
