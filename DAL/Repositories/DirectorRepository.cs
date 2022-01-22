using Microsoft.EntityFrameworkCore;
using Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DirectorRepository : Repository<Director>
    {
        public DirectorRepository(MovieContext context) : base(context)
        {
        }

        public override async Task<ICollection<Director>> GetAllAsync()
        {
            return await Context.Directors
                .Include(e => e.Gender)
                .Include(e => e.Movies)
                .ToListAsync();
        }

        public override async Task<Director> GetByIdAsync(int id)
        {
            return await Context.Directors
                .Include(e => e.Gender)
                .Include(e => e.Movies)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
