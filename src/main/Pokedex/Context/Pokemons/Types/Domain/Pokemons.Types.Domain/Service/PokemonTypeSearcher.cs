using Pokemons.Types.Domain.ValueObject;
using System.Threading.Tasks;

namespace Pokemons.Types.Domain.Service
{
    public class PokemonTypeSearcher
    {
        private PokemonTypeRepository _pokemonTypeRepository;

        public PokemonTypeSearcher(PokemonTypeRepository pokemonTypeRepository)
        {
            _pokemonTypeRepository = pokemonTypeRepository;
        }

        public Task<PokemonTypes> Execute(PokemonName pokemonName)
        {
            return _pokemonTypeRepository.Search(pokemonName);
        }
    }
}
