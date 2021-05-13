using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Pokemons.Pokemons.Domain.ValueObject;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Users.Users.Domain.Entities;
using Users.Users.Domain.Repositories;


namespace Users.Users.Persistence
{
    public class RabbitMqEventPublisher : EventSubscriber
    {
        public async Task<PokemonId> Subscribe(DomainEvent domainEvent)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost", Port = 5672, UserName = "guest", Password = "guest", VirtualHost = "library"
            };
        
            using (var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                   
                };
                channel.BasicConsume(queue: "domain_pokemon_add_event",
                    autoAck: true,
                    consumer: consumer);

              
            }

            return new PokemonId(0);
        }


        

     
    }
}