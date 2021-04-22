using Pokemons.Types.Domain.Aggregate;
using Pokemons.Types.Domain.Test.Aggregate;
using Pokemons.Types.Domain.ValueObject;
using System.Collections.Generic;

namespace Pokemons.Types.Domain.Test.ValueObject
{
    public class PokemonTypesMother
    {
        public List<PokemonTypeMother> Types { get; set; }

        public static PokemonTypes PokemonTypes()
        {
            return new PokemonTypes()
            {
                Types = new List<PokemonType>()
                {
                    new PokemonType
                    {
                        PokemonTypeName = new PokemonTypeName { Name = "fire" }
                    },
                    new PokemonType
                    {
                        PokemonTypeName = new PokemonTypeName { Name = "flying" }
                    },
                }
            };
        }
    }
}
