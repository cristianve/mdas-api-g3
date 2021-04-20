using Pokemons.Types.Domain.Service;
using System.Threading.Tasks;
using Pokemons.Types.Domain.ValueObject;

namespace Pokemons.Types.Application.UseCase
{
    public class GetPokemonType
    {
        private PokemonTypeSearcher _pokemonTypeSearcher;

        public GetPokemonType(PokemonTypeSearcher pokemonTypeSearcher)
        {
            _pokemonTypeSearcher = pokemonTypeSearcher;
        }

        public Task<PokemonTypes> Execute(string pokemonName)
        {
            return _pokemonTypeSearcher.Execute(new PokemonName() { Name = pokemonName });
        }
    }
}