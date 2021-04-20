using System;

namespace Pokemons.Types.Domain.Exceptions
{
    public class PokeApiNotFoundException : Exception
    {
        public PokeApiNotFoundException(string message) : base(message)
        {
        }
    }
}
