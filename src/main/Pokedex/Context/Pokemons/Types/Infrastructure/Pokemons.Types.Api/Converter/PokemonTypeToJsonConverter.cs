using Newtonsoft.Json;
using Pokemons.Types.Domain.ValueObject;
using System.Linq;

namespace Pokemons.Types.Api.Converter
{
    public class PokemonTypeToJsonConverter
    {
        public static string Execute(PokemonTypes pokemonTypes)
        {
            return JsonConvert.SerializeObject(
                pokemonTypes.Types.Select(s => new
                {
                    Name = s.PokemonTypeName.Name
                }));
        }
    }
}
