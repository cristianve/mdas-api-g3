namespace Pokemons.Pokemons.Domain.ValueObject
{
    public class PokemonType
    {
        public string Type { get; }

        public PokemonType(string type)
        {
            Type = type;
        }
    }
}
