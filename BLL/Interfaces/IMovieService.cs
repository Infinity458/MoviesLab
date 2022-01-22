using Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMovieService
    {
        public Task CreateMovie(Movie movie);

        public Task UpdateMovie(Movie movie);

        public Task<Movie> DeleteMovie(int movieId);

        public Task<ICollection<Movie>> GetAllMovies();

        public Task<Movie> GetMovieById(int movieId);

        public Task<ICollection<Movie>> GetMoviesByName(string name);

        public Task DeleteAll();
    }
}
