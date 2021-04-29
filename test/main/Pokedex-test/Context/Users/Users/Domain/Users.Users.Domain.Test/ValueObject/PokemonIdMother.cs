using System;
using System.Linq;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Test.ValueObject
{
    public class PokemonIdMother
    {
        private static int _id = 6;
        private static Random random = new Random();
        private const int NUM_OF_CHARS = 8;

        public static string Random()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, NUM_OF_CHARS)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static int Id()
        {
            return _id;
        }

        public static PokemonId PokemonId()
        {
            return new PokemonId(_id);
        }
    }
}
