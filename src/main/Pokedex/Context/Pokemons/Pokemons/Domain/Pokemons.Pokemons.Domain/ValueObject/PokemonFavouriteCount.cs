namespace Pokemons.Pokemons.Domain.ValueObject
{
    public class PokemonFavouriteCount
    {
        public int Count { get; }

        public PokemonFavouriteCount(int count)
        {
            Count = count;
        }
    }
}
