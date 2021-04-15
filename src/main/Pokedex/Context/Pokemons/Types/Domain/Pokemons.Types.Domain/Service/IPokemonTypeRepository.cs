using System.Threading.Tasks;
using Pokemons.Types.Domain.ValueObject;

namespace Pokemons.Types.Domain.Service
{
    public interface IPokemonTypeRepository
    {
        Task<PokemonTypes> Find(string pokemonName);
    }
}
