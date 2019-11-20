using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        // GET api/city
        [HttpGet]
        public async Task<IEnumerable<City>> Get()
        {
            return await _cityRepository.GetListOfCities();
        }
    }
}