namespace BikeRental.Contracts.Rent;

public class RentDto
{
    /// <summary>
    /// Уникальный идентификатор записи об аренде
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Велосипед, который был арендован
    /// </summary>
    public int? BikeId { get; set; }

    /// <summary>
    /// Клиент, арендовавший велосипед
    /// </summary>
    public int? CustomerId { get; set; }

    /// <summary>
    /// Дата и время начала аренды.
    /// По умолчанию устанавливается в текущее время
    /// </summary>
    public required DateTime? Start { get; set; }

    /// <summary>
    /// Дата и время окончания аренды
    /// По умолчанию устанавливается аренда на час
    /// </summary>
    public required DateTime? End { get; set; }
}
