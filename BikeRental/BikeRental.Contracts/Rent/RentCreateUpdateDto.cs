using BikeRental.Domain.Model;

namespace BikeRental.Contracts.Rent;

public class RentCreateUpdateDto
{
    public int? BikeId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? Start { get; set; }

    public DateTime? End { get; set; }
}
