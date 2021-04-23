using System.Threading.Tasks;
using Users.Users.Domain.Service;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Application.UseCase
{
    public class AddPokemonToUserFavorites
    {
        private readonly UserFinder _userFinder;

        public AddPokemonToUserFavorites(UserFinder userFinder)
        {
            _userFinder = userFinder;
        }

        public async Task Execute(string userId, string pokemonName)
        {
            var user = await _userFinder.Execute(new UserId(userId));
            user.AddPokemonFavorite(new PokemonName(pokemonName));
        }
    }
}