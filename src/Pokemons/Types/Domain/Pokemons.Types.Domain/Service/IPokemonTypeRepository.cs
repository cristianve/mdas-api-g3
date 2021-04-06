using System.Collections.Generic;
using System.Threading.Tasks;
using Pokemons.Types.Domain.ValueObject;

namespace Pokemons.Types.Domain.Service
{
    public interface IPokemonTypeRepository
    {
        Task<IEnumerable<PokemonType>> Find(string pokemonName);
    }
}
