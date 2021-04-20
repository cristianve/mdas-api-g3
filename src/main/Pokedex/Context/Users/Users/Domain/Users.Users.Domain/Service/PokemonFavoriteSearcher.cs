using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Service
{
    public class PokemonFavoriteSearcher
    {
        private UserRepository _userRepository;

        public PokemonFavoriteSearcher(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<PokemonFavorite>> Execute(User user)
        {
            var userFound = await _userRepository.FindUser(user);

            if (userFound == null)
            {
                return new List<PokemonFavorite>();
            }

            return userFound.PokemonFavorites;
        }
    }
}
