using Newtonsoft.Json.Linq;
using Pokemons.Pokemons.Api.Test.Response;
using System.Linq;

namespace Pokemons.Pokemons.Api.Test.Converter
{
    public class JsonToPokemonResponseConverter
    {
        public static PokemonResponse Execute(JObject json)
        {
            return new PokemonResponse(
                    int.Parse(json["Id"].ToString()),
                    json["Name"].ToString(),
                    json["Types"].Select(x => x.ToString()).ToList().ToArray()
                    );
        }
    }
}
