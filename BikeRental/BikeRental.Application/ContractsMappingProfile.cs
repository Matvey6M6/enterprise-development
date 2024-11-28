using AutoMapper;
using BikeRental.Contracts.Rent;
using BikeRental.Domain.Model;

namespace BikeRental.Application;

public class ContractsMappingProfile: Profile
{
    public ContractsMappingProfile()
    {
        CreateMap<RentCreateUpdateDto, Rent>().ReverseMap();
        CreateMap<RentDto, Rent>().ReverseMap();
    }
}
