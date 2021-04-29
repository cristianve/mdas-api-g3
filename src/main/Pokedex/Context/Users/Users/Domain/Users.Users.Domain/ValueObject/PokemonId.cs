using Users.Users.Domain.Exceptions;

namespace Users.Users.Domain.ValueObject
{
    public class PokemonId
    {
        public int Id { get; }

        public PokemonId(int id)
        {
            if (id == 0)
            {
                throw new PokemonFavoriteIsEmptyException();
            }

            Id = id;
        }
    }
}