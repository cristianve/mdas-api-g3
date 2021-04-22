using System.Collections.Generic;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Test.Aggregate
{
    public class UserMother
    {
        public UserId UserId { get; }
        public List<PokemonFavorite> PokemonFavorites { get; private set; }

        public UserMother(string userId)
        {
            UserId = new UserId()
            {
                Id = userId
            };

            PokemonFavorites = new List<PokemonFavorite>();
        }
    }
}
