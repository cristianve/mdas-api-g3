using System;

namespace Pokemons.Types.Domain.Exceptions
{
    public class PokemonNotFoundException : Exception
    {
        public string PokemonName { get; set; }

        public override string Message
            => $"Pokemon '{PokemonName}' does not exist";
    }
}
