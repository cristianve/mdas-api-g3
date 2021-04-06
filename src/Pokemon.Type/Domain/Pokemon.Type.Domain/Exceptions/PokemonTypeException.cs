using System;

namespace Pokemon.Type.Domain.Exceptions
{
    [Serializable]
    public class PokemonTypeException : Exception
    {
        public PokemonTypeException()
        {
        }

        public PokemonTypeException(string message) : base(message)
        {
        }

        public PokemonTypeException(string message, Exception inner) : base(message, inner)
        {
        }

        protected PokemonTypeException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
