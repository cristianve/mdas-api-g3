using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Users.Users.Api.Test.Drivers
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

        public async Task<HttpResponseMessage> CreateUser(string userId)
        {
            var client = factory.CreateClient();
            var path = $"/users/user/create/{userId}";
            var httpContent = new StringContent(userId, Encoding.UTF8, "application/json");

            return await client.PutAsync(path, httpContent);
        }

        public async Task<HttpResponseMessage> SaveFavorites(string userId, int pokemonId)
        {
            var client = factory.CreateClient();
            var path = $"/users/user/addFavorite/{pokemonId}";
            var httpContent = new StringContent(pokemonId.ToString(), Encoding.UTF8, "application/json");
            httpContent.Headers.Add("userId", userId);

            return await client.PutAsync(path, httpContent);
        }

        public async Task<HttpResponseMessage> GetFavorites(string userId)
        {
            var client = factory.CreateClient();
            var path = $"/users/user/favorites/{userId}";

            return await client.GetAsync(path);
        }
    }
}
