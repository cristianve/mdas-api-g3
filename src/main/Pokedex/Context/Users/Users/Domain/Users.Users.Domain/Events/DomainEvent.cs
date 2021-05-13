using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Entities
{
    public class DomainEvent
    {
        public MessageEvent MessageEvent { get; }

        public DomainEvent(MessageEvent messageEvent)
        {
            MessageEvent = messageEvent;
        }
    }
}