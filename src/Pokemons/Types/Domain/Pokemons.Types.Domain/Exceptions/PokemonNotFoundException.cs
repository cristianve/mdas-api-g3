using System;

namespace Pokemons.Types.Domain.Exceptions
{
    [Serializable]
    public class PokemonNotFoundException : DomainException
    {
        public PokemonNotFoundException()
        {
        }

        public PokemonNotFoundException(string message) : base(message)
        {
        }

        public PokemonNotFoundException(string message, int statusCode) : base(message, statusCode)
        {
        }

        public PokemonNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected PokemonNotFoundException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
