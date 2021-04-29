using Users.Users.Domain.Entities;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Aggregate
{
    public class User
    {
        public UserId UserId { get; }
        public PokemonFavorites PokemonFavorites { get; }

        public User(UserId userId)
        {
            UserId = userId;
            PokemonFavorites = new PokemonFavorites();
        }

        public static User Create(UserId userId)
        {
            return new User(userId);
        }

        public void AddPokemonFavorite(PokemonFavorite favorite)
        {
            PokemonFavorites.AddFavorite(favorite);
        }
    }
}