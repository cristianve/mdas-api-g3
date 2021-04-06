using System;

namespace Pokemons.Types.Domain.Exceptions
{
    [Serializable]
    public class PokeApiException : DomainException
    {
        public PokeApiException()
        {
        }

        public PokeApiException(string message) : base(message)
        {
        }

        public PokeApiException(string message, int statusCode) : base(message, statusCode)
        {
        }

        public PokeApiException(string message, Exception inner) : base(message, inner)
        {
        }

        protected PokeApiException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
