using System.Collections.Generic;
using Users.Users.Domain.Exceptions;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Aggregate
{
    public class User
    {
        public UserId UserId { get; }
        public List<PokemonFavorite> PokemonFavorites { get; private set; }

        public User(string userId)
        {
            UserId = new UserId()
            {
                Id = userId
            };

            PokemonFavorites = new List<PokemonFavorite>();
        }

        public User(string userId, string pokemonName)
        {
            UserId = new UserId()
            {
                Id = userId
            };

            PokemonFavorites = new List<PokemonFavorite>();

            if (string.IsNullOrEmpty(pokemonName))
            {
                throw new PokemonFavoriteIsEmptyException();
            }

            PokemonFavorites.Add(new PokemonFavorite() { PokemonName = pokemonName });
        }

        public static User Create(string userId, string pokemonName)
        {
            return new User(userId, pokemonName);
        }

        public static User Create(string userId)
        {
            return new User(userId);
        }
    }
}
