using AutoMapper;
using BikeRental.Contracts.Bike;
using BikeRental.Contracts.Customer;
using BikeRental.Contracts.Rent;
using BikeRental.Domain.Model;

namespace BikeRental.Application;

public class ContractsMappingProfile: Profile
{
    public ContractsMappingProfile()
    {
        CreateMap<RentCreateUpdateDto, Rent>().ReverseMap();
        CreateMap<RentDto, Rent>().ReverseMap();
        CreateMap<BikeCreateUpdateDto, Bike>().ReverseMap();
        CreateMap<Bike, BikeDto>().ReverseMap();
        CreateMap<CustomerCreateUpdateDto, Customer>().ReverseMap();
        CreateMap<Customer, CustomerDto>().ReverseMap();
    }
}
