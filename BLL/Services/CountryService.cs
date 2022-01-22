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
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> repository;

        public CountryService(IRepository<Country> repository)
        {
            this.repository = repository;
        }

        public Task CreateCountry(Country country)
        {
            return repository.CreateAsync(country);
        }

        public Task DeleteAll()
        {
            return repository.Clear();
        }

        public Task<Country> DeleteCountry(int countryId)
        {
            return repository.DeleteItemAsync(countryId);
        }

        public Task<ICollection<Country>> GetAllCountries()
        {
            return repository.GetAllAsync();
        }

        public async Task<ICollection<City>> GetCitiesByCountryId(int countryId)
        {
            return (await repository.GetByIdAsync(countryId)).Cities;
        }

        public Task<Country> GetCountryById(int countrytId)
        {
            return repository.GetByIdAsync(countrytId);
        }

        public Task UpdateCountry(Country country)
        {
            return repository.UpdateItemAsync(country);
        }
    }
}
