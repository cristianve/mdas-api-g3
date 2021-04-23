using System.Threading.Tasks;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Service
{
    public class PokemonFavoriteCreator
    {
        private readonly UserRepository _userRepository;

        public PokemonFavoriteCreator(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Execute (User user, PokemonName pokemonName)
        {
            user.AddPokemonFavorite(pokemonName);
            await _userRepository.SaveFavorites(user);
        }
    }
}
