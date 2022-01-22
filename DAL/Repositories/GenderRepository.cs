using Microsoft.EntityFrameworkCore;
using Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenderRepository : Repository<Gender>
    {
        public GenderRepository(MovieContext context) : base(context)
        {
        }

        public override async Task<ICollection<Gender>> GetAllAsync()
        {
            return await Context.Genders
                .Include(e => e.Actors)
                .Include(e => e.Directors)
                .ToListAsync();
        }

        public override async Task<Gender> GetByIdAsync(int id)
        {
            return await Context.Genders
                .Include(e => e.Actors)
                .Include(e => e.Directors)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
