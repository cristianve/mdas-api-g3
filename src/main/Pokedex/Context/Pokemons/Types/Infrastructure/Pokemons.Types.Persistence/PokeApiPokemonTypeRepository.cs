using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Pokemons.Types.Domain.Aggregate;
using Pokemons.Types.Domain.Exceptions;
using Pokemons.Types.Domain.Service;
using Pokemons.Types.Domain.ValueObject;

namespace Pokemons.Types.Persistence
{
    public class PokeApiPokemonTypeRepository : IPokemonTypeRepository
    {
        private const string API_URL = "https://pokeapi.co/api/v2/";
        private HttpClient _httpClient;

        public PokeApiPokemonTypeRepository()
        {
            _httpClient = new HttpClient();
        }

        public async Task<PokemonTypes> Find(string pokemonName)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, API_URL + $"pokemon/{pokemonName}");
            
            try
            {
                var json = await Request(request);

                return new PokemonTypes()
                {
                    Types = json["types"].Values("type").Select(x => new PokemonType
                    {
                        PokemonTypeName = new PokemonTypeName()
                        {
                            Name = x["name"].ToString()
                        }
                    }).ToList()
                };
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

        private async Task<JObject> Request(HttpRequestMessage request)
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

                StreamReader reader = new StreamReader(stream);
                return JObject.Parse(reader.ReadToEnd());
            }
        }
    }
}
