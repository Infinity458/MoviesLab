using Microsoft.EntityFrameworkCore;
using Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductionCompanyRepository : Repository<ProductionCompany>
    {
        public ProductionCompanyRepository(MovieContext context) : base(context)
        {
        }

        public override async Task<ICollection<ProductionCompany>> GetAllAsync()
        {
            return await Context.ProductionCompanies
                .Include(e => e.Movies)
                .ToListAsync();
        }

        public override async Task<ProductionCompany> GetByIdAsync(int id)
        {
            return await Context.ProductionCompanies
                .Include(e => e.Movies)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
