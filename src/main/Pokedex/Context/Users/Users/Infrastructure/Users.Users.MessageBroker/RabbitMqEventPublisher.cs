using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Users.Users.Domain.Entities;
using Users.Users.Domain.Repositories;

namespace Users.Users.Persistence
{
    public class RabbitMqEventPublisher : EventPublisher
    {
        public async Task Publish(DomainEvent domainEvent)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost", Port = 5672, UserName = "guest", Password = "guest", VirtualHost = "library"
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.BasicPublish(exchange: "",
                    routingKey: "notify_pokemon_on_add_favourite",
                    basicProperties: null,
                    body: Encoding.UTF8.GetBytes(domainEvent.MessageEvent.Message));
            }
        }


        public async Task Publish(IList<DomainEvent> events)
        {
            foreach (var domainEvent in events)
            {
                Publish(domainEvent);
            }
        }


     
    }
}