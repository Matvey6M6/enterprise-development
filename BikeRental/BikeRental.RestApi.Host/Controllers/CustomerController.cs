using BikeRental.Contracts;
using BikeRental.Contracts.Customer;

namespace BikeRental.RestApi.Host.Controllers;

public class CustomerController(ICrudService<CustomerDto, CustomerCreateUpdateDto, int> crudService, ILogger<CustomerController> logger)
    : CrudControllerBase<CustomerDto, CustomerCreateUpdateDto, int>(crudService, logger)
{
}