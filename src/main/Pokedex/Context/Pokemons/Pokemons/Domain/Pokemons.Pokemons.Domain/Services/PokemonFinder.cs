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
            GuardPokemonNotFound(pokemonId);
            return await _pokemonRepository.Find(pokemonId);
        }

        private void GuardPokemonNotFound(PokemonId pokemonId)
        {
            if (!_pokemonRepository.Exists(pokemonId).Result) throw new PokemonNotFoundException(pokemonId);
        }
    }
}
