using Domain;
using Repository;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class CityService : ICityService
    {
        private readonly IRepository<City> _repository;
        public CityService(IRepository<City> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<City>> GetAllCities()
        {
            try
            {

                return await _repository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
