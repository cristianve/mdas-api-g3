using Pokemons.Types.Domain.Exceptions;
using Pokemons.Types.Domain.Service;
using Pokemons.Types.Domain.ValueObject;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pokemons.Types.Infrastructure
{
    public class PokeApiPokemonTypeRepository : IPokemonTypeRepository
    {
        private const string API_URL = "https://pokeapi.co/api/v2/";
        private HttpClient _httpClient;

        public PokeApiPokemonTypeRepository()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<PokemonType>> Find(string pokemonName)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, API_URL + $"pokemon/{pokemonName}");
            
            try
            {
                Pokemon pokemon = await Request<Pokemon>(request);

                return pokemon.Types
                   .Select(s => new PokemonType
                   {
                       Name = s.Type.Name
                   });
            }
            catch (PokeApiException ex)
            {
                if (ex.StatusCode == 404)
                {
                    throw new PokemonNotFoundException("Pokemon " + pokemonName + " does not exist");
                }

                throw;
            }
        }

        private async Task<T> Request<T>(HttpRequestMessage request)
        {
            using (var response = await _httpClient
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode == false)
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new PokeApiException(message, (int)response.StatusCode);
                }

                var stream = await response.Content.ReadAsStreamAsync();
                var _options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return await JsonSerializer.DeserializeAsync<T>(stream, _options);
            }
        }
    }
}
