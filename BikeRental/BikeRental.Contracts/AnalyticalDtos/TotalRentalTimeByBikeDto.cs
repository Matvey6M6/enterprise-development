using BikeRental.Domain.Enums;

namespace BikeRental.Contracts.AnalyticalDtos;

public record TotalRentalTimeByBikeDto(BikeType? Type, double? TotalTime);
