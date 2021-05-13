using Users.Users.Domain.Exceptions;

namespace Users.Users.Domain.ValueObject
{
    public class MessageEvent
    {
        public string Message { get; }

        public MessageEvent(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new InvalidPokemonException();
            }

            Message = message;
        }
    }
}