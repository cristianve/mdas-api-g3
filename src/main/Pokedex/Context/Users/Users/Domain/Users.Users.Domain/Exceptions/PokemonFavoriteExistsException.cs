using System;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Exceptions
{
    public class PokemonFavoriteExistsException : Exception
    {
        private PokemonName _pokemonName;

        public override string Message
            => $"The pokemon '{_pokemonName.Name}' already exists in user favorites list";

        public PokemonFavoriteExistsException(PokemonName pokemonName)
        {
            _pokemonName = pokemonName;
        }
    }
}