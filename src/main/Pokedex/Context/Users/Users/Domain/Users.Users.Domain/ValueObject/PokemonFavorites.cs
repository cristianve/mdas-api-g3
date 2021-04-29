using System.Collections.Generic;
using System.Linq;
using Users.Users.Domain.Entities;
using Users.Users.Domain.Exceptions;

namespace Users.Users.Domain.ValueObject
{
    public class PokemonFavorites
    {
        public List<PokemonFavorite> Favorites { get; }

        public PokemonFavorites()
        {
            Favorites = new List<PokemonFavorite>();
        }

        public void AddFavorite(PokemonFavorite favorite)
        {
            GuardPokemonFavoriteExistsInUser(favorite);

            Favorites.Add(favorite);
        }

        #region private methods
        private void GuardPokemonFavoriteExistsInUser(PokemonFavorite favorite)
        {
            if (Favorites.Any(pokemonFavorite => pokemonFavorite.PokemonId.Id == favorite.PokemonId.Id))
            {
                throw new PokemonFavoriteExistsException(favorite);
            }
        }
        #endregion
    }
}
