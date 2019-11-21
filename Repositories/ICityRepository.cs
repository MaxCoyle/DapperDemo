using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetListOfCities();
        Task<int> AddCity(City newCity);
    }
}