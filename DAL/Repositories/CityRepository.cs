using Microsoft.EntityFrameworkCore;
using Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CityRepository : Repository<City>
    {
        public CityRepository(MovieContext context) : base(context)
        {
        }

        public override async Task<ICollection<City>> GetAllAsync()
        {
            return await Context.Cities
                .Include(e => e.Country)
                .ToListAsync();
        }

        public override async Task<City> GetByIdAsync(int id)
        {
            return await Context.Cities
                .Include(e => e.Country)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
