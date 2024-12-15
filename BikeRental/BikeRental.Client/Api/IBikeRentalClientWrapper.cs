namespace BikeRental.Client.Api;

public interface IBikeRentalClientWrapper
{
    public Task<BikeDto> CreateBike(BikeCreateUpdateDto newAuhtor);
    public Task<CustomerDto> CreateCustomer(CustomerCreateUpdateDto newCustomer);
    public Task<RentDto> CreateRent(RentCreateUpdateDto newRent);

    public Task<BikeDto> UpdateBike(int id, BikeCreateUpdateDto newAuhtor);
    public Task<CustomerDto> UpdateCustomer(int id, CustomerCreateUpdateDto newCustomer);
    public Task<RentDto> UpdateRent(int id, RentCreateUpdateDto newRent);

    public Task DeleteBike(int id);
    public Task DeleteCustomer(int id);
    public Task DeleteRent(int id);

    public Task<BikeDto> GetBike(int id);
    public Task<CustomerDto> GetCustomer(int id);
    public Task<RentDto> GetRent(int id);

    public Task<IList<BikeDto>> GetAllBikes();
    public Task<IList<CustomerDto>> GetAllCustomers();
    public Task<IList<RentDto>> GetAllRents();
}
