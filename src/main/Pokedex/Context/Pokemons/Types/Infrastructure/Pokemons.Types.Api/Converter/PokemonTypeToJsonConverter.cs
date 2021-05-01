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
                new
                {
                    Types = pokemonTypes.Types.Select(s => s.PokemonTypeName.Name)
                });
        }
    }
}
