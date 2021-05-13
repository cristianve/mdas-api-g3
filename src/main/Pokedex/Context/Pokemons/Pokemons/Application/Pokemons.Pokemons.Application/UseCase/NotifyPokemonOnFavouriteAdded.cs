using Pokemons.Pokemons.Domain.Aggregate;
using Pokemons.Pokemons.Domain.Services;
using Pokemons.Pokemons.Domain.ValueObject;
using System.Threading.Tasks;
using Pokemons.Pokemons.Domain.Repositories;

namespace Pokemons.Pokemons.Application.UseCase
{
    public class NotifyPokemonOnFavouriteAdded
    {
        
        private PokemonRepository _pokemonRepository;

        public void Execute(PokemonId pokemonId)
        {
             _pokemonRepository.UpdateFavouriteCount(pokemonId);
        }
    }
}
