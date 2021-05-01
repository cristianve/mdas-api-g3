using Newtonsoft.Json;
using System.Linq;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Api.Converter
{
    public class PokemonFavoritesToJsonConverter
    {
        public static string Execute(PokemonFavorites pokemonFavorites)
        {
            return JsonConvert.SerializeObject(
                new
                {
                    Favorites = pokemonFavorites.Favorites.Select(s => s.PokemonId.Id)
                });
        }
    }
}
