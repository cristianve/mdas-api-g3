namespace Pokemons.Pokemons.Domain.Test.ValueObject
{
    public class PokemonIdMother
    {
        private static int _id = 6;

        public static int Id()
        {
            return _id;
        }

        public static int IdUnknown()
        {
            return 0;
        }
    }
}
