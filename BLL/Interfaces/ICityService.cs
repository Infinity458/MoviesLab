using Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICityService
    {
        public Task CreateCity(City city);

        public Task DeleteAll();

        public Task UpdateCity(City city);

        public Task<City> DeleteCity(int cityId);

        public Task<ICollection<City>> GetAllCities();

        public Task<City> GetCityById(int cityId);

        public Task<ICollection<Actor>> GetActorsByCityId(int cityId);
    }
}
