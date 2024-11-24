namespace BikeRental.Domain.Model;

public class Rent
{
    public int Id { get; set; }

    public required Bike Bike { get; set; }

    public required Customer Customer { get; set; }

    public required DateTime Start { get; set; } = DateTime.Now;

    public required DateTime End { get; set; } = DateTime.Now.AddHours(1);
}
