using Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICountryService
    {
        public Task CreateCountry(Country country);

        public Task DeleteAll();

        public Task UpdateCountry(Country country);

        public Task<Country> DeleteCountry(int countryId);

        public Task<ICollection<Country>> GetAllCountries();

        public Task<Country> GetCountryById(int countrytId);

        public Task<ICollection<City>> GetCitiesByCountryId(int countryId);
    }
}
