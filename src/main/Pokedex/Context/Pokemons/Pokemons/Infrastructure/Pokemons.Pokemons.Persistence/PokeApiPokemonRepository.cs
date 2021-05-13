using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Caching.Memory;
using Pokemons.Pokemons.Domain.Aggregate;
using Pokemons.Pokemons.Domain.Exceptions;
using Pokemons.Pokemons.Domain.Repositories;
using Pokemons.Pokemons.Domain.ValueObject;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokemons.Pokemons.Persistence
{
    public class PokeApiPokemonRepository : PokemonRepository
    {
        private const string API_URL = "https://pokeapi.co/api/v2/";
        private const string CACHE_KEY_PREFIX = "pokemons/";
        
        private HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        
        public PokeApiPokemonRepository(IMemoryCache memoryCache)
        {
            _httpClient = new HttpClient();
            _memoryCache = memoryCache;
        }

        public async Task UpdateFavouriteCount(PokemonId pokemonId)
        {
            var cacheKey = GetCacheKey(pokemonId.Id.ToString());

            var previousValue =  _memoryCache.TryGetValue(cacheKey, out Pokemon pokemonInMemory);

            _memoryCache.Set(cacheKey, previousValue);
        }

        
        public async Task<bool> Exists(PokemonId pokemonId)
        {
            return (await Find(pokemonId)) != null;
        }

        public async Task<Pokemon> Find(PokemonId pokemonId)
        {
            var json = await Request(API_URL + $"pokemon/{pokemonId.Id}");

            if (json == null) return null;

            return new Pokemon(
                new PokemonId(int.Parse(json["id"].ToString())),
                new PokemonName(json["name"].ToString()),
                new PokemonTypes(json["types"].Values("type").Select(x => new PokemonType(x["name"].ToString())).ToList()),
                new PokemonFavouriteCount(0)
                );
        }

        private async Task<JObject> Request(string url)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                using (var response = await _httpClient
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
                {
                    if (response.IsSuccessStatusCode == false)
                    {
                        var message = await response.Content.ReadAsStringAsync();

                        if ((int)response.StatusCode == 404)
                        {
                            return null;
                        }

                        throw new Exception(message);
                    }

                    var stream = await response.Content.ReadAsStreamAsync();

                    StreamReader reader = new StreamReader(stream);
                    return JObject.Parse(reader.ReadToEnd());
                }
            }
            catch (Exception)
            {
                throw new PokeApiRepositoryException();
            }
        }
        
        private string GetCacheKey(string key)
        {
            return CACHE_KEY_PREFIX + key;
        }
        
        private string GetCacheValue(string value)
        {
            return CACHE_KEY_PREFIX + value;
        }
        
    }
    
    
}
