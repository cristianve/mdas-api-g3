using System.Collections.Generic;

namespace Pokemon.Type.Domain.ValueObject
{
    public class Pokemon
    {
        public string Name { get; set; }
        public List<PokemonSlot> Types { get; set; }
    }
}
