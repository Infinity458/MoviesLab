using Microsoft.EntityFrameworkCore;
using Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CountryRepository : Repository<Country>
    {
        public CountryRepository(MovieContext context) : base(context)
        {
        }

        public override async Task<ICollection<Country>> GetAllAsync()
        {
            return await Context.Countries
                .Include(e => e.Cities)
                .ToListAsync();
        }

        public override async Task<Country> GetByIdAsync(int id)
        {
            return await Context.Countries
                .Include(e => e.Cities)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
