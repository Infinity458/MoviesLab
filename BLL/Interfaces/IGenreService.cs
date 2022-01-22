using Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenreService
    {
        public Task CreateGenre(Genre genre);

        public Task DeleteAll();

        public Task UpdateGenre(Genre genre);

        public Task<Genre> DeleteGenre(int genreId);

        public Task<ICollection<Genre>> GetAllGenres();

        public Task<Genre> GetGenreById(int genreId);

        public Task<ICollection<Movie>> GetMoviesByGenreId(int genreId);
    }
}
