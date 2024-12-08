namespace BikeRental.Contracts.Customer;

public class CustomerDto
{
    /// <summary>
    /// Уникальный идентификатор клиента
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    /// Полное имя клиента
    /// </summary>
    public string? FullName { get; set; }

    /// <summary>
    /// Дата рождения клиента
    /// </summary>
    public DateOnly? BirthDate { get; set; }

    /// <summary>
    /// Номер телефона клиента
    /// </summary>
    public string? PhoneNumber { get; set; }
}
