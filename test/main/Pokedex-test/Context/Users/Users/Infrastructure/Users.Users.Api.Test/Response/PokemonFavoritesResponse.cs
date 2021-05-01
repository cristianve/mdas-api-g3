namespace Users.Users.Api.Test.Response
{
    public class PokemonFavoritesResponse
    {
        public int[] Favorites { get; }

        public PokemonFavoritesResponse(int[] favorites)
        {
            Favorites = favorites;
        }
    }
}
