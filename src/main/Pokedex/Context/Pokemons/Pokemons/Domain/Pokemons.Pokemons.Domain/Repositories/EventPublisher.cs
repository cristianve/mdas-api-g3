using System.Collections.Generic;
using System.Threading.Tasks;
using Pokemons.Pokemons.Domain.ValueObject;
using Users.Users.Domain.Entities;

namespace Users.Users.Domain.Repositories
{
    public interface EventSubscriber
    {
        public Task<PokemonId> Subscribe(DomainEvent domainEvent);
        
        //public Task<IList<PokemonId>> Subscribe(IList<DomainEvent> domainEvents);

    }
}