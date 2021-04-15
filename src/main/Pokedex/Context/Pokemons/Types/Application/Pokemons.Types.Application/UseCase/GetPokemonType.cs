using Pokemons.Types.Domain.Service;
using System.Threading.Tasks;
using Pokemons.Types.Domain.Aggregate;

namespace Pokemons.Types.Application.UseCase
{
    public class GetPokemonType
    {
        private IPokemonTypeRepository _pokemonTypeRepository;

        public GetPokemonType(IPokemonTypeRepository pokemonTypeRepository)
        {
            _pokemonTypeRepository = pokemonTypeRepository;
        }

        public Task<PokemonType> Execute(string pokemonName)
        {
            return _pokemonTypeRepository.Find(pokemonName);
        }
    }
}