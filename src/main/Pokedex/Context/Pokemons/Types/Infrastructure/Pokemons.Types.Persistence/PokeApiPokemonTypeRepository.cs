using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Pokemons.Types.Domain.Aggregate;
using Pokemons.Types.Domain.Exceptions;
using Pokemons.Types.Domain.Repositories;
using Pokemons.Types.Domain.ValueObject;
using Shared.Domain.Exceptions;
using Shared.Domain.Services;
using Shared.Domain.ValueObject;

namespace Pokemons.Types.Persistence
{
    public class PokeApiPokemonTypeRepository : PokemonTypeRepository
    {
        private const string API_URL = "https://pokeapi.co/api/v2/";
        private Request _request;

        public PokeApiPokemonTypeRepository(Request request)
        {
            _request = request;
        }

        public async Task<PokemonTypes> Search(PokemonName pokemonName)
        { 
            try
            {
                var json = await _request.Get(new UrlRequest(API_URL + $"pokemon/{pokemonName.Name}"));

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
