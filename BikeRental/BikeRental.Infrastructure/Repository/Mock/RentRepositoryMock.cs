using BikeRental.Contracts;
using BikeRental.Domain.Model;
using BikeRental.Infrastructure.DataSeed;

namespace BikeRental.Infrastructure.Repository.Mock;

public class RentRepositoryMock: IRepository<Rent, int>
{
    private static readonly List<Rent> Rents = BikeRentalSeeder.GetRents();

    public Task<List<Rent>> GetAsList()
    {
        return Task.FromResult(Rents.ToList());
    }

    public Task<Rent?> GetByKey(int key)
    {
        var rent = Rents.FirstOrDefault(r => r.Id == key);
        return Task.FromResult(rent);
    }

    public Task Add(Rent newRecord)
    {
        newRecord.Id = Rents.Max(c => c.Id) + 1;
        Rents.Add(newRecord);
        return Task.CompletedTask;
    }

    public Task Delete(int key)
    {
        var rent = Rents.FirstOrDefault(r => r.Id == key);
        if (rent != null)
        {
            Rents.Remove(rent);
        }
        return Task.CompletedTask;
    }

    public Task Update(int key, Rent newValue)
    {
        var rent = Rents.FirstOrDefault(r => r.Id == key);
        if (rent != null)
        {
            rent.Bike = newValue.Bike;
            rent.Customer = newValue.Customer;
            rent.Start = newValue.Start;
            rent.End = newValue.End;
        }
        return Task.CompletedTask;
    }
}
