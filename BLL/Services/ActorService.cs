using BLL.Filtres;
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
    public class ActorService : IActorService
    {
        private readonly IRepository<Actor> repository;

        public ActorService(IRepository<Actor> repository)
        {
            this.repository = repository;
        }

        public Task CreateActor(Actor actor)
        {
            return repository.CreateAsync(actor);
        }

        public Task<Actor> DeleteActor(int actorId)
        {
            return repository.DeleteItemAsync(actorId);
        }

        public Task DeleteAll()
        {
            return repository.Clear();
        }

        public Task<Actor> GetActorById(int actorId)
        {
            return repository.GetByIdAsync(actorId);
        }

        public Task<ICollection<Actor>> GetActorsById(ActorFilter filter)
        {
            Expression<Func<Actor, bool>> expression = e => filter.Ids.Contains(e.Id);
            return repository.GetByFilterAsync(expression);
        }

        public Task<ICollection<Actor>> GetActorsByName(string name)
        {
            Expression<Func<Actor, bool>> expression = e => e.Name == name;
            return repository.GetByFilterAsync(expression);
        }

        public Task<ICollection<Actor>> GetAllActors()
        {
            return repository.GetAllAsync();
        }

        public async Task<ICollection<Movie>> GetMoviesByActorId(int actorId)
        {
            return (await repository.GetByIdAsync(actorId)).Movies;
        }

        public Task UpdateActor(Actor actor)
        {
            return repository.UpdateItemAsync(actor);
        }
    }
}
