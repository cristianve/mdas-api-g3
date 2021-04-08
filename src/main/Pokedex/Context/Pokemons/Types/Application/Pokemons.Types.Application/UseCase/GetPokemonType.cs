using Pokemons.Types.Application.Request;
using Pokemons.Types.Application.Response;
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

        public async Task<GetPokemonTypeResponse> Execute(GetPokemonTypeRequest request)
        {
            var types = await _pokemonTypeRepository.Find(request.PokemonName);

            return new GetPokemonTypeResponse
            {
                Types = types.Select(s => s.Name).ToArray()
            };
        }
    }
}
