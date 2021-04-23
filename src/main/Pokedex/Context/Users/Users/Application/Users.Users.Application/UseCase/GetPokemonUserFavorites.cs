using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Users.Domain.Entities;
using Users.Users.Domain.Service;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Application.UseCase
{
    public class GetPokemonUserFavorites
    {
        private readonly UserFinder _userFinder;
        private readonly PokemonFavoriteSearcher _pokemonFavoriteSearcher;

        public GetPokemonUserFavorites(UserFinder userFinder, 
            PokemonFavoriteSearcher pokemonFavoriteSearcher)
        {
            _userFinder = userFinder;
            _pokemonFavoriteSearcher = pokemonFavoriteSearcher;
        }

        public async Task<List<PokemonFavorite>> Execute(string userId)
        {
            var user = await _userFinder.Execute(new UserId(userId));
            return _pokemonFavoriteSearcher.Execute(user);
        }
    }
}