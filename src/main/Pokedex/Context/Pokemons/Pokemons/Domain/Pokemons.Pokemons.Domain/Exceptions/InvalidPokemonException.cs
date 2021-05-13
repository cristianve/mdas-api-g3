using System;

namespace Users.Users.Domain.Exceptions
{
    public class InvalidPokemonException : Exception
    {
        public override string Message => $"Invalid user";
    }
}