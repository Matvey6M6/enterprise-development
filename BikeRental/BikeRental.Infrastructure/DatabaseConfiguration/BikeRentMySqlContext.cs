using BikeRental.Domain.Model;
using BikeRental.Infrastructure.DataSeed;
using Microsoft.EntityFrameworkCore;

namespace BikeRental.Infrastructure.DatabaseConfiguration;

public class BikeRentMySqlContext : DbContext
{
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<Customer> Customesrs { get; set; }
    public DbSet<Rent> Rents { get; set; }

    public BikeRentMySqlContext(DbContextOptions<BikeRentMySqlContext> options)
       : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Bike>().HasData(BikeRentalSeeder.GetBikes());
        modelBuilder.Entity<Customer>().HasData(BikeRentalSeeder.GetCustomers());
        modelBuilder.Entity<Rent>().HasData(BikeRentalSeeder.GetRents());
    }
}
