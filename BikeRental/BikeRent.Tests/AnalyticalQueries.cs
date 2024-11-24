using BikeRental.Domain.Enums;
using BikeRental.Domain.Model;
using BikeRental.Infrastructure.DataSeed;

namespace BikeRent.Tests
{
    public class AnalyticalQueries
    {
        private static List<Bike> Bikes = BikeRentalTest.GetBikes();
        private static List<Rent> Rents = BikeRentalTest.GetRents();
        private static List<Customer> Customers = BikeRentalTest.GetCustomers();

        [Fact]
        public void GetAllSportBikes()
        {
            // Вывести информацию обо всех спортивных велосипедах.
            var sportBikes = Bikes.Where(b => b.Type == BikeType.Sport).ToList();

            Assert.NotEmpty(sportBikes);
            sportBikes.ForEach(bike => 
                Assert.Equal(BikeType.Sport, bike.Type)
            );
        }

        [Fact]
        public void GetCustomersWithMountainBikesSortedByName()
        {
            // Вывести информацию обо всех клиентах, которые брали в аренду горные велосипеды, упорядочить по ФИО.
            var mountainBikeCustomers = Rents
                .Where(r => r.Bike.Type == BikeType.Mountain)
                .Select(r => r.Customer)
                .Distinct()
                .OrderBy(c => c.FullName)
                .ToList();

            Assert.NotEmpty(mountainBikeCustomers);
            Assert.True(mountainBikeCustomers.SequenceEqual(mountainBikeCustomers.OrderBy(c => c.FullName)));
        }

        [Fact]
        public void GetTotalRentalTimeByBikeType()
        {
            // Вывести суммарное время аренды велосипедов каждого типа.
            var totalRentalTimeByType = Rents
                .GroupBy(r => r.Bike.Type)
                .Select(g => new
                {
                    BikeType = g.Key,
                    TotalTime = g.Sum(r => (r.End - r.Start).TotalHours)
                })
                .ToList();

            Assert.NotEmpty(totalRentalTimeByType);
            foreach (var entry in totalRentalTimeByType)
            {
                Assert.True(entry.TotalTime > 0);
            }
        }

        [Fact]
        public void GetCustomersWithMostRentals()
        {
            // Вывести информацию о клиентах, бравших велосипеды на прокат больше всего раз.
            var maxRentCount = Rents
                .GroupBy(r => r.Customer)
                .OrderByDescending(g => g.Count())
                .First().Count();

            var topCustomers = Rents
                .GroupBy(r => r.Customer)
                .Where(g => g.Count() == maxRentCount)
                .Select(g => g.Key)
                .ToList();

            Assert.NotEmpty(topCustomers);
        }

        [Fact]
        public void GetTop5MostRentedBikes()
        {
            // Вывести информацию о топ 5 наиболее часто арендуемых велосипедов.
            var topBikes = Rents
                .GroupBy(r => r.Bike)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => g.Key)
                .ToList();

            Assert.NotEmpty(topBikes);
            Assert.True(topBikes.Count <= 5);
        }

        [Fact]
        public void GetMinMaxAverageRentalTime()
        {
            // Вывести информацию о минимальном, максимальном и среднем времени аренды велосипедов.
            var rentalTimes = Rents
                .Select(r => (r.End - r.Start).TotalHours)
                .ToList();

            var minTime = rentalTimes.Min();
            var maxTime = rentalTimes.Max();
            var averageTime = rentalTimes.Average();

            Assert.True(minTime > 0);
            Assert.True(maxTime >= minTime);
            Assert.True(averageTime >= minTime && averageTime <= maxTime);
        }
    }
}