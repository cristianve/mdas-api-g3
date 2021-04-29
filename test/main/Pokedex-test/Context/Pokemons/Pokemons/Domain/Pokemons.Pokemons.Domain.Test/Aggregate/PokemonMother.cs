using Pokemons.Pokemons.Domain.Test.ValueObject;
using Pokemons.Pokemons.Domain.ValueObject;
using System.Collections.Generic;

namespace Pokemons.Pokemons.Domain.Test.Aggregate
{
    public class PokemonMother
    {
        public PokemonId PokemonId { get; set; }
        public PokemonName PokemonName { get; set; }
        public PokemonTypes PokemonTypes { get; set; }

        public static PokemonMother Pokemon()
        {
            return new PokemonMother()
            {
                PokemonId = new PokemonId(PokemonIdMother.Id()),
                PokemonName = new PokemonName(PokemonNameMother.Name()),
                PokemonTypes = new PokemonTypes(new List<PokemonType>()
                {
                    new PokemonType("fire"),
                    new PokemonType("flying"),
                })
            };
        }
    }
}
