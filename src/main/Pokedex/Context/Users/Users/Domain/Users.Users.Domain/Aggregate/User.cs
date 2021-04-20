using System.Collections.Generic;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Aggregate
{
    public class User
    {
        public UserId UserId { get; set; }
        public List<PokemonFavorite> PokemonFavorites { get; set; }
    }
}
