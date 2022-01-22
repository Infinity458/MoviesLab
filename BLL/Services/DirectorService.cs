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
    public class DirectorService : IDirectorService
    {
        private readonly IRepository<Director> repository;

        public DirectorService(IRepository<Director> repository)
        {
            this.repository = repository;
        }

        public Task CreateDirector(Director director)
        {
            return repository.CreateAsync(director);
        }

        public Task DeleteAll()
        {
            return repository.Clear();
        }

        public Task<Director> DeleteDirector(int directorId)
        {
            return repository.DeleteItemAsync(directorId);
        }

        public Task<ICollection<Director>> GetAllDirectors()
        {
            return repository.GetAllAsync();
        }

        public Task<Director> GetDirectorById(int directorId)
        {
            return repository.GetByIdAsync(directorId);
        }

        public Task<ICollection<Director>> GetDirectorsByName(string name)
        {
            Expression<Func<Director, bool>> expression = e => e.Name == name;
            return repository.GetByFilterAsync(expression);
        }

        public async Task<ICollection<Movie>> GetMoviesByDirectorId(int directorId)
        {
            return (await repository.GetByIdAsync(directorId)).Movies;
        }

        public Task UpdateDirector(Director director)
        {
            return repository.UpdateItemAsync(director);
        }
    }
}
