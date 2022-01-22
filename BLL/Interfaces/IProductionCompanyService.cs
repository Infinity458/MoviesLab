using Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProductionCompanyService
    {
        public Task<ICollection<ProductionCompany>> GetAllProductionCompanies();

        public Task<ProductionCompany> GetProductionCompanyById(int productionCompanyId);

        public Task<ICollection<Movie>> GetMoviesByProductionCompanyId(int productionCompanyId);
    }
}
