using BikeRental.Contracts;
using BikeRental.Contracts.Rent;

namespace BikeRental.RestApi.Host.Controllers;

public class RentController(ICrudService<RentDto, RentCreateUpdateDto, int> crudService, ILogger<RentController> logger)
    : CrudControllerBase<RentDto, RentCreateUpdateDto, int>(crudService, logger)
{
}