using System.Collections.Generic;
using Pokemons.Types.Domain.Aggregate;

namespace Pokemons.Types.Domain.ValueObject
{
    public class PokemonTypes
    {
        public List<PokemonType> Types { get; set; }
    }
}