using Pokemons.Types.Application.Response;
using Pokemons.Types.Domain.Exceptions;
using Pokemons.Types.Domain.Service;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemons.Types.Application.UseCase
{
    public class GetPokemonType
    {
        private IPokemonTypeRepository _pokemonTypeRepository;

        public GetPokemonType(IPokemonTypeRepository pokemonTypeRepository)
        {
            _pokemonTypeRepository = pokemonTypeRepository;
        }

        public async Task<GetPokemonTypeResponse> Execute(string pokemonName)
        {
            var types = await _pokemonTypeRepository.Find(pokemonName);

            if (types == null)
                throw new PokemonNotFoundException("Pokemon " + pokemonName + " does not exist");

            return new GetPokemonTypeResponse
            {
                Types = types.Select(s => s.Name).ToArray()
            };
        }
    }
}
