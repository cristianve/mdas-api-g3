using Pokemons.Types.Domain.ValueObject;
using System.Collections.Generic;
using System.Linq;

namespace Pokemons.Types.CliConsole.Converter
{
    public class PokemonTypeToStringConverter
    {
        public static string Execute(IEnumerable<PokemonType> pokemonTypes)
        {
            return string.Join(", ", pokemonTypes.Select(s => s.Name).ToArray());
        }
    }
}
