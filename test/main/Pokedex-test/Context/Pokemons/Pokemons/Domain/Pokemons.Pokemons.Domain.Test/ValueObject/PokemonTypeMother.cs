using System;
using System.Linq;

namespace Pokemons.Pokemons.Domain.Test.ValueObject
{
    public class PokemonTypeMother
    {
        private static Random random = new Random();
        private const int NUM_OF_CHARS = 8;

        public static string Random()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, NUM_OF_CHARS)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
