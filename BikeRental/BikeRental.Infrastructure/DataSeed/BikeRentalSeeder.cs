using BikeRental.Domain.Enums;
using BikeRental.Domain.Model;

namespace BikeRental.Infrastructure.DataSeed;

public static class BikeRentalSeeder
{
    public static List<Bike> GetBikes()
    {
        return new List<Bike>
        {
            new Bike { SerialNumber = 1, Type = BikeType.Mountain, Model = "X-Trail 500", Color = "Red", CostPerPrice = 1500m },
            new Bike { SerialNumber = 2, Type = BikeType.Touring, Model = "EasyRide 200", Color = "Blue", CostPerPrice = 1000m },
            new Bike { SerialNumber = 3, Type = BikeType.Sport, Model = "Speedster 3000", Color = "Black", CostPerPrice = 2000m },
            new Bike { SerialNumber = 4, Type = BikeType.Sport, Model = "Racer Pro 9000", Color = "Green", CostPerPrice = 3000m },
            new Bike { SerialNumber = 5, Type = BikeType.Mountain, Model = "RockClimber X", Color = "Yellow", CostPerPrice = 1200m },
            new Bike { SerialNumber = 6, Type = BikeType.Touring, Model = "City Explorer", Color = "White", CostPerPrice = 4000m }
        };
    }

    public static List<Customer> GetCustomers()
    {
        return new List<Customer>
        {
            new Customer { Id = 1, FullName = "Тест Тестов", BirthDate = new DateOnly(1990, 5, 20), PhoneNumber = "88005553535" },
            new Customer { Id = 2, FullName = "Дима Нова", BirthDate = new DateOnly(1985, 3, 15), PhoneNumber = "88005553530" },
            new Customer { Id = 3, FullName = "Иероним Карл Фридрих фон Мюнхгаузен", BirthDate = new DateOnly(2000, 12, 1), PhoneNumber = "718005553535" },
            new Customer { Id = 4, FullName = "Alice Johnson", BirthDate = new DateOnly(1995, 7, 15), PhoneNumber = "555-123-9876" },
            new Customer { Id = 5, FullName = "Chris Evans", BirthDate = new DateOnly(1992, 11, 25), PhoneNumber = "444-321-8765" },
            new Customer { Id = 6, FullName = "Emma Wilson", BirthDate = new DateOnly(1988, 2, 5), PhoneNumber = "333-987-6543" }
        };
    }

    public static List<Rent> GetRents()
    {
        var bikes = GetBikes();
        var customers = GetCustomers();

        return new List<Rent>
        {
            new Rent { Id = 1, BikeId = bikes[0].SerialNumber, CustomerId = customers[0].Id, Start = DateTime.Now.AddHours(-2), End = DateTime.Now.AddHours(2) },
            new Rent { Id = 2, BikeId = bikes[1].SerialNumber, CustomerId = customers[1].Id, Start = DateTime.Now.AddHours(-1), End = DateTime.Now.AddHours(3) },
            new Rent { Id = 3, BikeId = bikes[2].SerialNumber, CustomerId = customers[2].Id, Start = DateTime.Now.AddHours(-3), End = DateTime.Now.AddHours(1) },
            new Rent { Id = 4, BikeId = bikes[3].SerialNumber, CustomerId = customers[3].Id, Start = DateTime.Now.AddHours(-4), End = DateTime.Now.AddHours(4) },
            new Rent { Id = 5, BikeId = bikes[4].SerialNumber, CustomerId = customers[4].Id, Start = DateTime.Now.AddHours(-2), End = DateTime.Now.AddHours(6) },
            new Rent { Id = 6, BikeId = bikes[5].SerialNumber, CustomerId = customers[5].Id, Start = DateTime.Now.AddHours(-1), End = DateTime.Now.AddHours(5) }

        };
    }
}
