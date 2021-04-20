using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Service;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Application.UseCase
{
    public class AddPokemonToFavorites
    {
        private PokemonFavoriteCreator _pokemonFavoriteCreator;

        public AddPokemonToFavorites(PokemonFavoriteCreator pokemonFavoriteCreator)
        {
            _pokemonFavoriteCreator = pokemonFavoriteCreator;
        }

        public async Task<PokemonFavorite> Execute(string userId, string pokemonName)
        {
            return await _pokemonFavoriteCreator.Execute(new User(userId, pokemonName));
        }
    }
}
