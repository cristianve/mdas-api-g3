using Pokemon.Type.Domain.Exceptions;
using Pokemon.Type.Domain.Service;
using Pokemon.Type.Domain.ValueObject;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pokemon.Type.Infrastructure
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
            Domain.ValueObject.Pokemon pokemon = await Request<Domain.ValueObject.Pokemon>(request);

            return pokemon.Types
                    .Select(s => new PokemonType
                    {
                        Name = s.Type.Name
                    });
        }

        private async Task<T> Request<T>(HttpRequestMessage request)
        {
            using (var response = await _httpClient
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new PokemonTypeException(content);
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
