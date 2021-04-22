using System.Collections.Generic;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Entities;

namespace Users.Users.Domain.Service
{
    public class PokemonFavoriteSearcher
    {
        public List<PokemonFavorite> Execute(User user)
        {
            return user.PokemonFavorites;
        }
    }
}