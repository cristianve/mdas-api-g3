using Pokemons.Pokemons.Domain.Aggregate;
using Pokemons.Pokemons.Domain.Services;
using Pokemons.Pokemons.Domain.ValueObject;
using System.Threading.Tasks;

namespace Pokemons.Pokemons.Application.UseCase
{
    public class GetPokemonById
    {
        private PokemonFinder _pokemonFinder;

        public GetPokemonById(PokemonFinder pokemonFinder)
        {
            _pokemonFinder = pokemonFinder;
        }

        public Task<Pokemon> Execute(int pokemonId)
        {
            return _pokemonFinder.Execute(new PokemonId(pokemonId));
        }
    }
}
