using Pokemon.Type.Domain.Exceptions;
using Pokemon.Type.Domain.Service;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemon.Type.Application.UseCase
{
    public class GetPokemonType
    {
        private IPokemonTypeRepository _pokemonTypeRepository;

        public GetPokemonType(IPokemonTypeRepository pokemonTypeRepository)
        {
            _pokemonTypeRepository = pokemonTypeRepository;
        }

        public async Task<string[]> Execute(string pokemonName)
        {
            var types = await _pokemonTypeRepository.Find(pokemonName);

            if (types == null)
                throw new PokemonNotFoundException("Pokemon " + pokemonName + " not found");

            return types.Select(s => s.Name).ToArray();
        }
    }
}
