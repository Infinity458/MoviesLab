using Microsoft.EntityFrameworkCore;
using Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MovieRepository : Repository<Movie>
    {
        public MovieRepository(MovieContext context) : base(context)
        {
        }

        public override async Task<ICollection<Movie>> GetAllAsync()
        {
            return await Context.Movies
                .Include(e => e.Director)
                .Include(e => e.Actors)
                .Include(e => e.ProductionCompany)
                .Include(e => e.Genre)
                .ToListAsync();
        }

        public override async Task<Movie> GetByIdAsync(int id)
        {
            return await Context.Movies
                .Include(e => e.Director)
                .Include(e => e.Actors)
                .Include(e => e.ProductionCompany)
                .Include(e => e.Genre)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
