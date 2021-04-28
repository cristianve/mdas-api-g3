using System.Threading.Tasks;
using Pokemons.Types.Domain.ValueObject;

namespace Pokemons.Types.Domain.Repositories
{
    public interface PokemonTypeRepository
    {
        Task<PokemonTypes> Search(PokemonName pokemonName);
    }
}
