using System.Threading.Tasks;
using Pokemons.Types.Domain.Aggregate;

namespace Pokemons.Types.Domain.Service
{
    public interface IPokemonTypeRepository
    {
        Task<PokemonType> Find(string pokemonName);
    }
}
