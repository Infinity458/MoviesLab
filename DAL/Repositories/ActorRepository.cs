using Microsoft.EntityFrameworkCore;
using Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ActorRepository : Repository<Actor>
    {
        public ActorRepository(MovieContext context) : base(context)
        {
        }

        public override async Task<ICollection<Actor>> GetAllAsync()
        {
            return await Context.Actors
                .Include(e => e.Gender)
                .Include(e => e.City)
                    .ThenInclude(e => e.Country)
                .Include(e => e.Movies)
                .ToListAsync();
        }

        public override async Task<Actor> GetByIdAsync(int id)
        {
            return await Context.Actors
                .Include(e => e.Gender)
                .Include(e => e.City)
                    .ThenInclude(e => e.Country)
                .Include(e => e.Movies)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
