using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Models;

namespace Repositories
{
    public class CityRepository : ICityRepository
    {
        private const string SelectAllCitiesSql = "SELECT Id, [Name], [Description] FROM City";
        private const string InsertNewCitySql = "INSERT INTO City([Name], [Description]) VALUES (@name, @description)";
        private readonly string _connectionString;

        public CityRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<City>> GetListOfCities()
        {
            List<City> cityList;
            using (var connection = new SqlConnection(_connectionString))
            {
                cityList = connection.Query<City>(SelectAllCitiesSql).ToList();
            }

            return await Task.FromResult(cityList);
        }

        public async Task<int> AddCity(City newCity)
        {
            int rowsAffected;
            using (var connection = new SqlConnection(_connectionString))
            {
                rowsAffected = connection.Execute(InsertNewCitySql, new { newCity.Name, newCity.Description });
            }

            return await Task.FromResult(rowsAffected);
        }
    }
}
