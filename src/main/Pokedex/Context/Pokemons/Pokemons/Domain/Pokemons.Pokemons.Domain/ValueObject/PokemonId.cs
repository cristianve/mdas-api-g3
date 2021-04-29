namespace Pokemons.Pokemons.Domain.ValueObject
{
    public class PokemonId
    {
        public int Id { get; }

        public PokemonId(int id)
        {
            Id = id;
        }
    }
}
