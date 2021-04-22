using Users.Users.Domain.Service;

namespace Users.Users.Application.UseCase
{
    public class AddPokemonToUserFavorites
    {
        private readonly UserFinder _userFinder;

        public AddPokemonToUserFavorites(UserFinder userFinder)
        {
            _userFinder = userFinder;
        }

        public void Execute(string userId, string pokemonName)
        {
            var user = _userFinder.Execute(userId);
            user.AddPokemonFavorite(pokemonName);
        }
    }
}