using BikeRental.Domain.Enums;

namespace BikeRental.Domain.Model;

public class Bike
{
    public required int SerialNumber { get; set; }

    public required BikeType Type { get; set; }

    public string? Model { get; set; }

    public string? Color { get; set; }

    public decimal CostPerPrice { get; set; }
}
