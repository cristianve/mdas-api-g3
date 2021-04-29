namespace Pokemons.Pokemons.Domain.ValueObject
{
    public class PokemonName
    {
        public string Name { get; }

        public PokemonName(string name)
        {
            Name = name;
        }
    }
}
