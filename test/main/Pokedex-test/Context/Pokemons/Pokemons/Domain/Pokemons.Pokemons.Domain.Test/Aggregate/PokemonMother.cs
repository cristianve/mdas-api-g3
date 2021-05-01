using Pokemons.Pokemons.Domain.Aggregate;
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

        public static Pokemon Pokemon()
        {
            return new Pokemon(new PokemonId(PokemonIdMother.Id()),
                new PokemonName(PokemonNameMother.Name()),
                new PokemonTypes(new List<PokemonType>()
                {
                    new PokemonType("fire"),
                    new PokemonType("flying"),
                }));
        }
    }
}
