using BikeRental.Domain.Enums;

namespace BikeRental.Domain.Model;

/// <summary>
/// Представляет сущность велосипеда
/// </summary>
public class Bike
{
    /// <summary>
    /// Уникальный серийный номер велосипеда.
    /// </summary>
    public required int SerialNumber { get; set; }

    /// <summary>
    /// Тип велосипеда
    /// </summary>
    public required BikeType Type { get; set; }

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
    public decimal CostPerPrice { get; set; }
}
