using Pokemons.Types.Domain.Service;
using System.Threading.Tasks;
using Pokemons.Types.Domain.ValueObject;

namespace Pokemons.Types.Application.UseCase
{
    public class GetPokemonTypes
    {
        private PokemonTypeSearcher _pokemonTypeSearcher;

        public GetPokemonTypes(PokemonTypeSearcher pokemonTypeSearcher)
        {
            _pokemonTypeSearcher = pokemonTypeSearcher;
        }

        public Task<PokemonTypes> Execute(string pokemonName)
        {
            return _pokemonTypeSearcher.Execute(new PokemonName() { Name = pokemonName });
        }
    }
}