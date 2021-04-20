using System;
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
    public class PokeApiPokemonTypeRepository : PokemonTypeRepository
    {
        private const string API_URL = "https://pokeapi.co/api/v2/";
        private HttpClient _httpClient;

        public PokeApiPokemonTypeRepository()
        {
            _httpClient = new HttpClient();
        }

        public async Task<PokemonTypes> Search(PokemonName pokemonName)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, API_URL + $"pokemon/{pokemonName.Name}");
            
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
            catch (PokeApiNotFoundException ex)
            {
                throw new PokemonNotFoundException(){ PokemonName = pokemonName.Name };
            }
        }

        private async Task<JObject> Request(HttpRequestMessage request)
        {
            try
            {
                using (var response = await _httpClient
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode == false)
                    {
                        var message = await response.Content.ReadAsStringAsync();

                        if ((int)response.StatusCode == 404)
                        {
                            throw new PokeApiNotFoundException(message);
                        }

                        throw new Exception(message);
                    }

                    var stream = await response.Content.ReadAsStreamAsync();

                    StreamReader reader = new StreamReader(stream);
                    return JObject.Parse(reader.ReadToEnd());
                }
            }
            catch (PokeApiNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new PokeApiException();
            }
        }
    }
}
