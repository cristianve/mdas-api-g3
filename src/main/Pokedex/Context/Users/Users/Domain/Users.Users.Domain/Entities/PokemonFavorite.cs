using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Entities
{
    public class PokemonFavorite
    {
        public PokemonId PokemonId { get; }

        public PokemonFavorite(PokemonId pokemonId)
        {
            PokemonId = pokemonId;
        }
    }
}