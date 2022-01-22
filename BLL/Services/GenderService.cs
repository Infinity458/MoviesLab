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
    public class GenderService : IGenderService
    {
        private readonly IRepository<Gender> repository;

        public GenderService(IRepository<Gender> repository)
        {
            this.repository = repository;
        }

        public async Task<ICollection<Actor>> GetActorsByGenderId(int genderId)
        {
            return (await repository.GetByIdAsync(genderId)).Actors;
        }

        public Task<ICollection<Gender>> GetAllGenders()
        {
            return repository.GetAllAsync();
        }

        public async Task<ICollection<Director>> GetDirectorsByGenderId(int genderId)
        {
            return (await repository.GetByIdAsync(genderId)).Directors;
        }

        public Task<Gender> GetGenderById(int genderId)
        {
            return repository.GetByIdAsync(genderId);
        }
    }
}
