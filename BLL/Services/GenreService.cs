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
    public class GenreService : IGenreService
    {
        private readonly IRepository<Genre> repository;

        public GenreService(IRepository<Genre> repository)
        {
            this.repository = repository;
        }

        public Task CreateGenre(Genre genre)
        {
            return repository.CreateAsync(genre);
        }

        public Task DeleteAll()
        {
            return repository.Clear();
        }

        public Task<Genre> DeleteGenre(int genreId)
        {
            return repository.DeleteItemAsync(genreId);
        }

        public Task<ICollection<Genre>> GetAllGenres()
        {
            return repository.GetAllAsync();
        }

        public Task<Genre> GetGenreById(int genreId)
        {
            return repository.GetByIdAsync(genreId);
        }

        public async Task<ICollection<Movie>> GetMoviesByGenreId(int genreId)
        {
            return (await repository.GetByIdAsync(genreId)).Movies;
        }

        public Task UpdateGenre(Genre genre)
        {
            return repository.UpdateItemAsync(genre);
        }
    }
}
