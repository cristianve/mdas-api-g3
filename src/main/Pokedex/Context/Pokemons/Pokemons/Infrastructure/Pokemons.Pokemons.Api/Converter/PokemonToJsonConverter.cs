using Newtonsoft.Json;
using Pokemons.Pokemons.Domain.Aggregate;

namespace Pokemons.Pokemons.Api.Converter
{
    public class PokemonToJsonConverter
    {
        public static string Execute(Pokemon pokemon)
        {
            return JsonConvert.SerializeObject(
                pokemon);
        }
    }
}
