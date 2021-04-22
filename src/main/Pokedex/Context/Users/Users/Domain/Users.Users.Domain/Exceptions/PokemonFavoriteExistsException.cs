using System;

namespace Users.Users.Domain.Exceptions
{
    public class PokemonFavoriteExistsException : Exception
    {
        public string PokemonName { get; set; }

        public override string Message
            => $"The pokemon '{PokemonName}' already exists in user favorites list";
    }
}