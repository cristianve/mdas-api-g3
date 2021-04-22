using Users.Users.Domain.Exceptions;

namespace Users.Users.Domain.ValueObject
{
    public class PokemonName
    {
        public string Name { get; set; }

        public PokemonName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new PokemonFavoriteIsEmptyException();
            }

            Name = name;
        }
    }
}