using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Service;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Application.UseCase
{
    public class GetPokemonFavorites
    {
        private PokemonFavoriteSearcher _pokemonFavoriteSearcher;

        public GetPokemonFavorites(PokemonFavoriteSearcher pokemonFavoriteSearcher)
        {
            _pokemonFavoriteSearcher = pokemonFavoriteSearcher;
        }

        public async Task<List<PokemonFavorite>> Execute(string userId)
        {
            return await _pokemonFavoriteSearcher.Execute(new User(userId));
        }
    }
}
