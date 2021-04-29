using Pokemons.Pokemons.Domain.Aggregate;
using Pokemons.Pokemons.Domain.ValueObject;
using System.Threading.Tasks;

namespace Pokemons.Pokemons.Domain.Repositories
{
    public interface PokemonRepository
    {
        Task<Pokemon> Find(PokemonId pokemonId);
        Task<bool> Exists(PokemonId pokemonId);
    }
}
