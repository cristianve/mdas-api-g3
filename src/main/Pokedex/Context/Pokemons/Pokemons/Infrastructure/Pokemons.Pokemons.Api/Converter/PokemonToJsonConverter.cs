using Newtonsoft.Json;
using Pokemons.Pokemons.Domain.Aggregate;
using System.Linq;

namespace Pokemons.Pokemons.Api.Converter
{
    public class PokemonToJsonConverter
    {
        public static string Execute(Pokemon pokemon)
        {
            return JsonConvert.SerializeObject(
                new
                {
                    Id = pokemon.PokemonId.Id,
                    Name = pokemon.PokemonName.Name,
                    Types = pokemon.PokemonTypes.Types.Select(s => s.Type)
                });
        }
    }
}
