using BikeRental.Domain.Model;
using BikeRental.Infrastructure.DataSeed;
using BikeRental.Tests.TestDataSeed;

namespace BikeRental.Tests.Fixture;

public class TestFixture
{
    public List<Bike> Bikes { get; }
    public List<Rent> Rents { get; }
    public List<Customer> Customers { get; }

    public TestFixture()
    {
        Bikes = TestBikeRentalSeeder.GetBikes();
        Rents = TestBikeRentalSeeder.GetRents();
        Customers = TestBikeRentalSeeder.GetCustomers();
    }
}

