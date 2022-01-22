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
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> repository;

        public MovieService(IRepository<Movie> repository)
        {
            this.repository = repository;
        }

        public Task CreateMovie(Movie movie)
        {
            return repository.CreateAsync(movie);
        }

        public Task DeleteAll()
        {
            return repository.Clear();
        }

        public Task<Movie> DeleteMovie(int movieId)
        {
            return repository.DeleteItemAsync(movieId);
        }

        public Task<ICollection<Movie>> GetAllMovies()
        {
            return repository.GetAllAsync();
        }

        public Task<Movie> GetMovieById(int movieId)
        {
            return repository.GetByIdAsync(movieId);
        }

        public Task<ICollection<Movie>> GetMoviesByName(string name)
        {
            Expression<Func<Movie, bool>> expression = e => e.Name == name;
            return repository.GetByFilterAsync(expression);
        }

        public Task UpdateMovie(Movie movie)
        {
            return repository.UpdateItemAsync(movie);
        }
    }
}
