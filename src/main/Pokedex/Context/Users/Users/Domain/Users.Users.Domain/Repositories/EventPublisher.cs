using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Users.Domain.Entities;

namespace Users.Users.Domain.Repositories
{
    public interface EventPublisher
    {
        public Task Publish(DomainEvent domainEvent);
        public Task Publish(IList<DomainEvent> domainEvents);

    }
}