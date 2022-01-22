using BLL.Interfaces;
using Domain.Enities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductionCompanyService : IProductionCompanyService
    {
        private readonly IRepository<ProductionCompany> repository;

        public ProductionCompanyService(IRepository<ProductionCompany> repository)
        {
            this.repository = repository;
        }

        public Task<ICollection<ProductionCompany>> GetAllProductionCompanies()
        {
            return repository.GetAllAsync();
        }

        public async Task<ICollection<Movie>> GetMoviesByProductionCompanyId(int productionCompanyId)
        {
            return (await repository.GetByIdAsync(productionCompanyId)).Movies;
        }

        public Task<ProductionCompany> GetProductionCompanyById(int productionCompanyId)
        {
            return repository.GetByIdAsync(productionCompanyId);
        }
    }
}
