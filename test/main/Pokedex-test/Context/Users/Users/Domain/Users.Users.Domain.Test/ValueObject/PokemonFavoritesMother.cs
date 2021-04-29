using Users.Users.Domain.Entities;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Test.ValueObject
{
    public class PokemonFavoritesMother
    {
        public static PokemonFavorites PokemonFavorites()
        {
            PokemonFavorites pokemonFavorites = new PokemonFavorites();
            pokemonFavorites.AddFavorite(new PokemonFavorite(new PokemonName("charizard")));
            return pokemonFavorites;
        }
    }
}
