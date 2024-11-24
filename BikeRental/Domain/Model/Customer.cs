namespace BikeRental.Domain.Model;

public class Customer
{
    public required int Id { get; set; }

    public string? FullName { get; set; }

    public DateOnly BirthDate { get; set; }

    public string? PhoneNumber { get; set; }
}
