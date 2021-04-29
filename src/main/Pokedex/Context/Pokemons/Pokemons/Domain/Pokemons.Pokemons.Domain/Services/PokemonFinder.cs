using Pokemons.Pokemons.Domain.Aggregate;
using Pokemons.Pokemons.Domain.Exceptions;
using Pokemons.Pokemons.Domain.Repositories;
using Pokemons.Pokemons.Domain.ValueObject;
using System.Threading.Tasks;

namespace Pokemons.Pokemons.Domain.Services
{
    public class PokemonFinder
    {
        private PokemonRepository _pokemonRepository;

        public PokemonFinder(PokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<Pokemon> Execute(PokemonId pokemonId)
        {
            Pokemon pokemon = await _pokemonRepository.Find(pokemonId);

            if (pokemon == null)
            {
                throw new PokemonNotFoundException(pokemonId);
            }

            return pokemon;
        }
    }
}
