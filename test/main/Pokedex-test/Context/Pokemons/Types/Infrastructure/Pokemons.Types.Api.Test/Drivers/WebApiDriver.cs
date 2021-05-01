using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokemons.Types.Api.Test.Drivers
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

        public async Task<HttpResponseMessage> GetTypes(string name)
        {
            var client = factory.CreateClient();
            var path = $"/pokedex/pokemons/types/{name}";

            return await client.GetAsync(path);
        }
    }
}
