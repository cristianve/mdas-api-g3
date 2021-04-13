using Newtonsoft.Json;
using Pokemons.Types.Domain.Aggregate;
using System.Linq;

namespace Pokemons.Types.Api.Converter
{
    public class PokemonTypeToJsonConverter
    {
        public static string Execute(PokemonType pokemonType)
        {
            return JsonConvert.SerializeObject(
                pokemonType.Types.Select(s => new
                {
                    Name = s.Name
                }));
        }
    }
}
