using DapperDemo.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
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

        // Execute a query and map the results to a strongly typed List
        [Fact]
        public async Task GetListOfCities()
        {
            // Arrange
            var cityRepository = new CityRepository(_dapperConfig.ConnectionString);

            // act
            var listOfCities = await cityRepository.GetListOfCities();

            // Assert
            Assert.NotEmpty(listOfCities);
        }

        // Execute a query and map it to a list of dynamic objects

        // Execute a Command that returns no results
    }
}
