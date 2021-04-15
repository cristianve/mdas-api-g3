using Pokemons.Types.Domain.ValueObject;
using System.Linq;

namespace Pokemons.Types.CliConsole.Converter
{
    public class PokemonTypeToStringConverter
    {
        public static string Execute(PokemonTypes pokemonTypes)
        {
            return string.Join(", ", pokemonTypes.Types.Select(s => s.PokemonTypeName.Name).ToArray());
        }
    }
}
