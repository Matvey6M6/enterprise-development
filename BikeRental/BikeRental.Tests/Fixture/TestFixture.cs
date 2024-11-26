using BikeRental.Domain.Model;
using BikeRental.Infrastructure.DataSeed;

namespace BikeRental.Tests.Fixture;

public class TestFixture
{
    public List<Bike> Bikes { get; }
    public List<Rent> Rents { get; }
    public List<Customer> Customers { get; }

    public TestFixture()
    {
        Bikes = BikeRentalSeeder.GetBikes();
        Rents = BikeRentalSeeder.GetRents();
        Customers = BikeRentalSeeder.GetCustomers();
    }
}

