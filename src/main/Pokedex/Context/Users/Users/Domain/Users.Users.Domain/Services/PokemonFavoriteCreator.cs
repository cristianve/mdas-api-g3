using System.Threading.Tasks;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Entities;
using Users.Users.Domain.Repositories;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Services
{
    public class PokemonFavoriteCreator
    {
        private readonly UserRepository _userRepository;

        public PokemonFavoriteCreator(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Execute(User user, PokemonFavorite pokemonFavorite)
        {
            user.AddPokemonFavorite(pokemonFavorite);
            await _userRepository.SaveFavorites(user);
        }
    }
}
