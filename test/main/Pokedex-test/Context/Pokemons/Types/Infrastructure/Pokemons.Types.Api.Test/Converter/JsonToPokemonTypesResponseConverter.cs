using Newtonsoft.Json.Linq;
using Pokemons.Types.Api.Test.Response;
using System.Linq;

namespace Pokemons.Types.Api.Test.Converter
{
    public class JsonToPokemonTypesResponseConverter
    {
        public static PokemonTypesResponse Execute(JObject json)
        {
            return new PokemonTypesResponse(
                    json["Types"].Select(x => x.ToString()).ToList().ToArray()
                    );
        }
    }
}
