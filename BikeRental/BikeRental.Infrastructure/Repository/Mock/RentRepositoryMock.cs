using BikeRental.Domain.Model;

namespace BikeRental.Infrastructure.Repository.Mock;

public class RentRepositoryMock
{
    private static readonly List<Rent> _rents = new List<Rent>();

    public Task<List<Rent>> GetAsList()
    {
        return Task.FromResult(_rents.ToList());
    }

    public Task<Rent?> GetByKey(int key)
    {
        var rent = _rents.FirstOrDefault(r => r.Id == key);
        return Task.FromResult(rent);
    }

    public Task Add(Rent newRecord)
    {
        newRecord.Id = _rents.Count + 1;
        _rents.Add(newRecord);
        return Task.CompletedTask;
    }

    public Task Delete(int key)
    {
        var rent = _rents.FirstOrDefault(r => r.Id == key);
        if (rent != null)
        {
            _rents.Remove(rent);
        }
        return Task.CompletedTask;
    }

    public Task Update(int key, Rent newValue)
    {
        var rent = _rents.FirstOrDefault(r => r.Id == key);
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
