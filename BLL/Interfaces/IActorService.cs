using BLL.Filtres;
using Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IActorService
    {
        public Task CreateActor(Actor actor);

        public Task UpdateActor(Actor actor);

        public Task<Actor> DeleteActor(int actorId);

        public Task<ICollection<Actor>> GetAllActors();

        public Task<Actor> GetActorById(int actorId);
        public Task<ICollection<Actor>> GetActorsById(ActorFilter filter);

        public Task<ICollection<Movie>> GetMoviesByActorId(int actorId);

        public Task<ICollection<Actor>> GetActorsByName(string name);

        public Task DeleteAll();
    }
}
