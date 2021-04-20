using System.Linq;
using System.Threading.Tasks;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Exceptions;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Service
{
    public class PokemonFavoriteCreator
    {
        private UserRepository _userRepository;

        public PokemonFavoriteCreator(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<PokemonFavorite> Execute(User user)
        {
            await guardPokemonFavoriteExistsInUser(user);

            return await _userRepository.AddFavorite(user);
        }

        private async Task guardPokemonFavoriteExistsInUser(User user)
        {
            if (await _userRepository.FavoriteExistsInUser(user))
            {
                throw new PokemonFavoriteExistsException(){ PokemonName = user.PokemonFavorites.FirstOrDefault().PokemonName };
            }
        }
    }
}
