namespace BikeRental.Client.Api;

public class BikeRentalClientWrapper(IConfiguration configuration) : IBikeRentalClientWrapper
{
    public readonly BikeRentalClient _client = new(configuration["OpenApi:ServerUrl"], new HttpClient());

    public async Task<BikeDto> CreateBike(BikeCreateUpdateDto newAuhtor) => await _client.BikePOSTAsync(newAuhtor);
    public async Task<CustomerDto> CreateCustomer(CustomerCreateUpdateDto newCustomer) => await _client.CustomerPOSTAsync(newCustomer);
    public async Task<RentDto> CreateRent(RentCreateUpdateDto newRent) => await _client.RentPOSTAsync(newRent);

    public async Task<BikeDto> UpdateBike(int id, BikeCreateUpdateDto newAuhtor) => await _client.BikePUTAsync(id, newAuhtor);
    public async Task<CustomerDto> UpdateCustomer(int id, CustomerCreateUpdateDto newCustomer) => await _client.CustomerPUTAsync(id, newCustomer);
    public async Task<RentDto> UpdateRent(int id, RentCreateUpdateDto newRent) => await _client.RentPUTAsync(id, newRent);

    public async Task DeleteBike(int id) => await _client.BikeDELETEAsync(id);
    public async Task DeleteCustomer(int id) => await _client.CustomerDELETEAsync(id);
    public async Task DeleteRent(int id) => await _client.RentDELETEAsync(id);

    public async Task<BikeDto> GetBike(int id) => await _client.BikeGETAsync(id);
    public async Task<CustomerDto> GetCustomer(int id) => await _client.CustomerGETAsync(id);
    public async Task<RentDto> GetRent(int id) => await _client.RentGETAsync(id);

    public async Task<IList<BikeDto>> GetAllBikes() => [.. await _client.BikeAllAsync()];
    public async Task<IList<CustomerDto>> GetAllCustomers() => [.. await _client.CustomerAllAsync()];
    public async Task<IList<RentDto>> GetAllRents() => [.. await _client.RentAllAsync()];
}
