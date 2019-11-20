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
    }
}
