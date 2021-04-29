﻿using System;
using Users.Users.Domain.Entities;

namespace Users.Users.Domain.Exceptions
{
    public class PokemonFavoriteExistsException : Exception
    {
        private PokemonFavorite _pokemonFavorite;

        public override string Message
            => $"The pokemon '{_pokemonFavorite.PokemonName.Name}' already exists in user favorites list";

        public PokemonFavoriteExistsException(PokemonFavorite pokemonName)
        {
            _pokemonFavorite = pokemonName;
        }
    }
}