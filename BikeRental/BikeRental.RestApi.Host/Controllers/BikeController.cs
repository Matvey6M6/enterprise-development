using BikeRental.Contracts;
using BikeRental.Contracts.Bike;
using BikeRental.Domain.Model;

namespace BikeRental.RestApi.Host.Controllers;

public class BikeController(ICrudService<BikeDto, BikeCreateUpdateDto, int> crudService, ILogger<BikeController> logger)
    : CrudControllerBase<BikeDto, BikeCreateUpdateDto, int>(crudService, logger)
{
}