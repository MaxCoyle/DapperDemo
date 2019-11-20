using System;
using DapperDemo.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Repositories;
using Xunit;

namespace IntegrationTests
{
    public class RepositoryTests
    {
        private readonly DapperConfig _dapperConfig;

        public RepositoryTests()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build();
            _dapperConfig = new DapperConfig(configuration);
        }
        
        [Fact]
        public async Task GetListOfCitiesIsSuccessful()
        {
            // Arrange
            var cityRepository = new CityRepository(_dapperConfig.ConnectionString);

            // act
            var listOfCities = await cityRepository.GetListOfCities();

            // Assert
            Assert.NotEmpty(listOfCities);
        }

        [Fact]
        public async Task AddNewCityToListOfCitiesIsSuccessful()
        {
            // Arrange
            var cityRepository = new CityRepository(_dapperConfig.ConnectionString);
            var expectedCity = new City
            {
                Name = $"Test City { Guid.NewGuid() }",
                Description = "City added via testing"
            };

            // act
            await cityRepository.AddCity(expectedCity);
            var listOfCities = (await cityRepository.GetListOfCities()).ToList();
            var actualCity = listOfCities.First(city => city.Name == expectedCity.Name);

            // Assert
            Assert.Equal(expectedCity.Name, actualCity.Name);
            Assert.Equal(expectedCity.Description, actualCity.Description);
        }
    }
}
