using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokemons.Pokemons.Api.Test.Drivers
{
    public class WebApiDriver
    {
        private WebApplicationFactory<Startup> factory;

        public WebApiDriver()
        {
            factory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                });
        }

        public async Task<HttpResponseMessage> GetPokemons(int id)
        {
            var client = factory.CreateClient();
            var path = $"/pokemons/{id}";

            return await client.GetAsync(path);
        }
    }
}
