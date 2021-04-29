using Pokemons.Types.Domain.ValueObject;
using System;

namespace Pokemons.Types.Domain.Exceptions
{
    public class PokemonNotFoundException : Exception
    {
        private PokemonName _pokemonName;

        public PokemonNotFoundException(PokemonName pokemonName)
        {
            _pokemonName = pokemonName;
        }

        public override string Message
            => $"Pokemon '{_pokemonName.Name}' does not exist";
    }
}
