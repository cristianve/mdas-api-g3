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

        public async Task<HttpResponseMessage> GetPokemons(int pokemonId)
        {
            var client = factory.CreateClient();
            var path = $"/pokedex/pokemons/pokemon/{pokemonId}";
            
            return await client.GetAsync(path);
        }
    }
}
