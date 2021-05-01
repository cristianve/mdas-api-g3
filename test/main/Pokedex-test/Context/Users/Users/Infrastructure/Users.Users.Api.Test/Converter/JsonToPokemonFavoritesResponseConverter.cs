using Newtonsoft.Json.Linq;
using System.Linq;
using Users.Users.Api.Test.Response;

namespace Users.Users.Api.Test.Converter
{
    public class JsonToPokemonFavoritesResponseConverter
    {
        public static PokemonFavoritesResponse Execute(JObject json)
        {
            return new PokemonFavoritesResponse(
                    json["Favorites"].Select(x => int.Parse(x.ToString())).ToList().ToArray()
                    );
        }
    }
}
