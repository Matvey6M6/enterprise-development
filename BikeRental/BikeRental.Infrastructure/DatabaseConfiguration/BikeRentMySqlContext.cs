using BikeRental.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.Infrastructure.DatabaseConfiguration;

public class BikeRentMySqlContext : DbContext
{
    public DbSet<Bike> Bikdes { get; set; }
    public DbSet<Customer> Customesrs { get; set; }
    public DbSet<Rent> Rents { get; set; }

    public BikeRentMySqlContext(DbContextOptions<BikeRentMySqlContext> options)
       : base(options)
    {
        Database.EnsureCreated();
    }
}
