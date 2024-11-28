namespace BikeRental.Contracts.Rent;

public class RentDto
{
    public int? Id { get; set; }

    public int? BikeId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? Start { get; set; }

    public DateTime? End { get; set; }
}
