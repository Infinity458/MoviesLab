using BLL.Interfaces;
using Domain.Enities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CityService : ICityService
    {
        private readonly IRepository<City> repository;

        public CityService(IRepository<City> repository)
        {
            this.repository = repository;
        }

        public Task CreateCity(City city)
        {
            return repository.CreateAsync(city);
        }

        public Task DeleteAll()
        {
            return repository.Clear();
        }

        public Task<City> DeleteCity(int cityId)
        {
            return repository.DeleteItemAsync(cityId);
        }

        public async Task<ICollection<Actor>> GetActorsByCityId(int cityId)
        {
            return (await repository.GetByIdAsync(cityId)).Actors;
        }

        public Task<ICollection<City>> GetAllCities()
        {
            return repository.GetAllAsync();
        }

        public Task<City> GetCityById(int cityId)
        {
            return repository.GetByIdAsync(cityId);
        }

        public Task UpdateCity(City city)
        {
            return repository.UpdateItemAsync(city);
        }
    }
}
