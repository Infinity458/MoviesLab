using Microsoft.EntityFrameworkCore;
using Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenreRepository : Repository<Genre>
    {
        public GenreRepository(MovieContext context) : base(context)
        {
        }

        public override async Task<ICollection<Genre>> GetAllAsync()
        {
            return await Context.Genres
                .Include(e => e.Movies)
                .ToListAsync();
        }

        public override async Task<Genre> GetByIdAsync(int id)
        {
            return await Context.Genres
                .Include(e => e.Movies)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
