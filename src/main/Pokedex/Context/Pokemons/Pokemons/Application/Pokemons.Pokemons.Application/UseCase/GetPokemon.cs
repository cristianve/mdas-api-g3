using Pokemons.Pokemons.Domain.Aggregate;
using Pokemons.Pokemons.Domain.Services;
using Pokemons.Pokemons.Domain.ValueObject;
using System.Threading.Tasks;

namespace Pokemons.Pokemons.Application.UseCase
{
    public class GetPokemon
    {
        private PokemonFinder _pokemonFinder;

        public GetPokemon(PokemonFinder pokemonFinder)
        {
            _pokemonFinder = pokemonFinder;
        }

        public Task<Pokemon> Execute(int pokemonId)
        {
            return _pokemonFinder.Execute(new PokemonId(pokemonId));
        }
    }
}
