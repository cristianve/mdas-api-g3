using Pokemons.Pokemons.Domain.ValueObject;
using System;

namespace Pokemons.Pokemons.Domain.Exceptions
{
    public class PokemonNotFoundException : Exception
    {
        private PokemonId _pokemonId;

        public PokemonNotFoundException(PokemonId pokemonId)
        {
            _pokemonId = pokemonId;
        }

        public override string Message
            => $"Pokemon with Id '{_pokemonId.Id}' does not exist";
    }
}
