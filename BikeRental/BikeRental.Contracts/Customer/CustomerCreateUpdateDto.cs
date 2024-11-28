namespace BikeRental.Contracts.Customer;

public class CustomerCreateUpdateDto
{
    public string? FullName { get; set; }

    public DateOnly BirthDate { get; set; }

    public string? PhoneNumber { get; set; }
}