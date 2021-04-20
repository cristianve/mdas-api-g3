using System.Threading.Tasks;
using Pokemons.Types.Domain.ValueObject;

namespace Pokemons.Types.Domain.Service
{
    public interface PokemonTypeRepository
    {
        Task<PokemonTypes> Search(PokemonName pokemonName);
    }
}
