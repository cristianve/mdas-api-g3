using System.Collections.Generic;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Entities;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Test.Aggregate
{
    public class UserMother
    {
        public UserId UserId { get; }
        public List<PokemonFavorite> PokemonFavorites { get; private set; }

        public UserMother(string userId)
        {
            UserId = new UserId(userId);

            PokemonFavorites = new List<PokemonFavorite>();
        }

        public static User User(string userId)
        {
            return new User(userId);
        }

        public static User UserWithFavorites(string userId, string pokemonName)
        {
            User user = new User(userId);
            user.AddPokemonFavorite(new PokemonName(pokemonName));
            return user;
        }
    }
}
