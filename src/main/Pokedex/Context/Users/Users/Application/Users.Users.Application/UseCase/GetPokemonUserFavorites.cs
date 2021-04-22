using System.Collections.Generic;
using Users.Users.Domain.Entities;
using Users.Users.Domain.Service;

namespace Users.Users.Application.UseCase
{
    public class GetPokemonUserFavorites
    {
        private readonly UserFinder _userFinder;
        private readonly PokemonFavoriteSearcher _pokemonFavoriteSearcher;

        public GetPokemonUserFavorites(UserFinder userFinder, PokemonFavoriteSearcher pokemonFavoriteSearcher)
        {
            _userFinder = userFinder;
            _pokemonFavoriteSearcher = pokemonFavoriteSearcher;
        }

        public List<PokemonFavorite> Execute(string userId)
        {
            var user = _userFinder.Execute(userId);
            return _pokemonFavoriteSearcher.Execute(user);
        }
    }
}