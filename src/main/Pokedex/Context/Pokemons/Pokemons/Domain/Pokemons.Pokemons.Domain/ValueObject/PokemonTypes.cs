using System.Collections.Generic;

namespace Pokemons.Pokemons.Domain.ValueObject
{
    public class PokemonTypes
    {
        public List<PokemonType> Types { get; }

        public PokemonTypes(List<PokemonType> types)
        {
            Types = types;
        }
    }
}
