using BikeRental.Contracts;
using BikeRental.Domain.Model;

namespace BikeRental.RestApi.Host.Controllers;

public class BikeController(ICrudService<Bike, Bike, int> crudService, ILogger<BikeController> logger)
    : CrudControllerBase<Bike, Bike, int>(crudService, logger)
{
}