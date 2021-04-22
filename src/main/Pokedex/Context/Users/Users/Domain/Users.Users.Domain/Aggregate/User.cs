using System.Collections.Generic;
using System.Linq;
using Users.Users.Domain.Entities;
using Users.Users.Domain.Exceptions;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Aggregate
{
    public class User
    {
        public UserId UserId { get; }
        public List<PokemonFavorite> PokemonFavorites { get; }

        public User(string userId)
        {
            UserId = new UserId()
            {
                Id = userId
            };

            PokemonFavorites = new List<PokemonFavorite>();
        }

        public static User Create(string userId)
        {
            GuardUserIdValidation(userId);
            return new User(userId);
        }

        private static void GuardUserIdValidation(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new InvalidUserException();
            }
        }

        public void AddPokemonFavorite(string pokemonName)
        {
            GuardPokemonFavoriteExistsInUser(pokemonName);

            PokemonFavorites.Add(new PokemonFavorite()
            {
                PokemonName = new PokemonName(pokemonName)
            });
        }

        private void GuardPokemonFavoriteExistsInUser(string pokemonName)
        {
            if (PokemonFavorites.Any(pokemonFavorite => pokemonFavorite.PokemonName.Name == pokemonName))
            {
                throw new PokemonFavoriteExistsException {PokemonName = pokemonName};
            }
        }
    }
}