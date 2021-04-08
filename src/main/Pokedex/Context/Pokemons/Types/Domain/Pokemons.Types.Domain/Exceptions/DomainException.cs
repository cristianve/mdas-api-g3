using System;

namespace Pokemons.Types.Domain.Exceptions
{
    [Serializable]
    public class DomainException : Exception
    {
        public int StatusCode { get; }

        public DomainException()
        {
        }

        public DomainException(string message) : base(message)
        {
        }

        public DomainException(string message, Exception inner) : base(message, inner)
        {
        }

        public DomainException(string message, int statusCode)
        : this(message)
        {
            StatusCode = statusCode;
        }

        protected DomainException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
