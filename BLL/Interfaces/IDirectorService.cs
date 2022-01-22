using Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDirectorService
    {
        public Task CreateDirector(Director director);

        public Task UpdateDirector(Director director);

        public Task<Director> DeleteDirector(int directorId);

        public Task<ICollection<Director>> GetAllDirectors();

        public Task<Director> GetDirectorById(int directorId);

        public Task<ICollection<Movie>> GetMoviesByDirectorId(int directorId);

        public Task<ICollection<Director>> GetDirectorsByName(string name);

        public Task DeleteAll();
    }
}
