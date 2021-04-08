namespace Pokemons.Types.CliConsole.Converter
{
    public class StringConverter
    {
        public static string Execute(string[] arrayData)
        {
            return string.Join(", ", arrayData);
        }
    }
}
