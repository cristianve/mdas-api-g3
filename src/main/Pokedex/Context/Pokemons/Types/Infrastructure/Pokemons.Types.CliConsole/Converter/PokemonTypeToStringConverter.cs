using Pokemons.Types.Domain.Aggregate;
using System.Linq;

namespace Pokemons.Types.CliConsole.Converter
{
    public class PokemonTypeToStringConverter
    {
        public static string Execute(PokemonType pokemonType)
        {
            return string.Join(", ", pokemonType.Types.Select(s => s.Name).ToArray());
        }
    }
}
