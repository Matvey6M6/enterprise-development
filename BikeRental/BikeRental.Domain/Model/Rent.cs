namespace BikeRental.Domain.Model;

/// <summary>
/// Представляет запись об аренде велосипеда
/// </summary>
public class Rent
{
    /// <summary>
    /// Уникальный идентификатор записи об аренде
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Велосипед, который был арендован
    /// </summary>
    public required Bike Bike { get; set; }

    /// <summary>
    /// Клиент, арендовавший велосипед
    /// </summary>
    public required Customer Customer { get; set; }

    /// <summary>
    /// Дата и время начала аренды.
    /// По умолчанию устанавливается в текущее время
    /// </summary>
    public required DateTime Start { get; set; } = DateTime.Now;

    /// <summary>
    /// Дата и время окончания аренды
    /// По умолчанию устанавливается аренда на час
    /// </summary>
    public required DateTime End { get; set; } = DateTime.Now.AddHours(1);
}