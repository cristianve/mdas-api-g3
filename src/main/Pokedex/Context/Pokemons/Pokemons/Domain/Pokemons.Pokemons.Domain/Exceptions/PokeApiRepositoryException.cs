using System;

namespace Pokemons.Pokemons.Domain.Exceptions
{
    public class PokeApiRepositoryException : Exception
    {
        public override string Message
            => $"An error occurred in the connection of the pokemon api";
    }
}
