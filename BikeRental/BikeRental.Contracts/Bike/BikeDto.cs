using BikeRental.Domain.Enums;

namespace BikeRental.Contracts.Bike;

public class BikeDto
{
    /// <summary>
    /// Уникальный серийный номер велосипеда.
    /// </summary>
    public int? SerialNumber { get; set; }

    /// <summary>
    /// Тип велосипеда
    /// </summary>
    public BikeType? Type { get; set; }

    /// <summary>
    /// Модель велосипеда
    /// </summary>
    public string? Model { get; set; }

    /// <summary>
    /// Цвет велосипеда
    /// </summary>
    public string? Color { get; set; }

    /// <summary>
    /// Стоимость аренды велосипеда в час
    /// </summary>
    public decimal? CostPerPrice { get; set; }
}
