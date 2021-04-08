namespace Pokemons.Types.CliConsole.Converter
{
    public class PokemonTypeToSpplitedStringConverter
    {
        public static string Execute(string[] arrayData)
        {
            return string.Join(", ", arrayData);
        }
    }
}
