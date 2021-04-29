using Newtonsoft.Json.Linq;
using Pokemons.Pokemons.Domain.Aggregate;
using Pokemons.Pokemons.Domain.Exceptions;
using Pokemons.Pokemons.Domain.Repositories;
using Pokemons.Pokemons.Domain.ValueObject;
using Shared.Domain.Exceptions;
using Shared.Domain.Services;
using Shared.Domain.ValueObject;
using System.Linq;
using System.Threading.Tasks;

namespace Pokemons.Pokemons.Persistence
{
    public class PokeApiPokemonRepository : PokemonRepository
    {
        private const string API_URL = "https://pokeapi.co/api/v2/";
        private Request _request;

        public PokeApiPokemonRepository(Request request)
        {
            _request = request;
        }

        public async Task<Pokemon> Find(PokemonId pokemonId)
        {
            try
            {
                var json = await _request.Get(new UrlRequest(API_URL + $"pokemon/{pokemonId.Id}"));

                return new Pokemon(
                    new PokemonId(int.Parse(json["id"].ToString())),
                    new PokemonName(json["name"].ToString()),
                    new PokemonTypes(json["types"].Values("type").Select(x => new PokemonType(x["name"].ToString())).ToList())
                    );
            }
            catch (HttpNotFoundException ex)
            {
                return null;
            }
            catch (HttpException ex)
            {
                throw new PokeApiException();
            }
        }
    }
}
