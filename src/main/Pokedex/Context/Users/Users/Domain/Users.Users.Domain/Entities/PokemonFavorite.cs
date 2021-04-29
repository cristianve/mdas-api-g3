using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Entities
{
    public class PokemonFavorite
    {
        public PokemonName PokemonName { get; }

        public PokemonFavorite(PokemonName pokemonName)
        {
            PokemonName = pokemonName;
        }
    }
}