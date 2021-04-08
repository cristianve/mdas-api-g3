using System.Collections.Generic;

namespace Pokemons.Types.Domain.ValueObject
{
    public class Pokemon
    {
        public string Name { get; set; }
        public List<PokemonSlot> Types { get; set; }
    }
}
