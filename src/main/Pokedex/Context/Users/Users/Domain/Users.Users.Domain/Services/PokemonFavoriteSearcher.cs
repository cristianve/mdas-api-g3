using Users.Users.Domain.Aggregate;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Services
{
    public class PokemonFavoriteSearcher
    {
        public PokemonFavorites Execute(User user)
        {
            return user.PokemonFavorites;
        }
    }
}