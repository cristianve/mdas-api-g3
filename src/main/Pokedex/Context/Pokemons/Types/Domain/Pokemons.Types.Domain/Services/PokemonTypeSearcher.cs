using Pokemons.Types.Domain.Exceptions;
using Pokemons.Types.Domain.Repositories;
using Pokemons.Types.Domain.ValueObject;
using System.Threading.Tasks;

namespace Pokemons.Types.Domain.Services
{
    public class PokemonTypeSearcher
    {
        private PokemonTypeRepository _pokemonTypeRepository;

        public PokemonTypeSearcher(PokemonTypeRepository pokemonTypeRepository)
        {
            _pokemonTypeRepository = pokemonTypeRepository;
        }

        public async Task<PokemonTypes> Execute(PokemonName pokemonName)
        {
            PokemonTypes pokemonTypes = await _pokemonTypeRepository.Search(pokemonName);

            if (pokemonTypes == null)
            {
                throw new PokemonNotFoundException(pokemonName);
            }

            return pokemonTypes;
        }
    }
}
