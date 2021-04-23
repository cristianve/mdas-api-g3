using System.Threading.Tasks;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Exceptions;

namespace Users.Users.Domain.Service
{
    public class UserCreator
    {
        private UserRepository _userRepository;

        public UserCreator(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Execute(User user)
        {
            GuardUserExists(user);
            await _userRepository.Save(user);
        }

        #region private methods
        private void GuardUserExists(User user)
        {
            if (_userRepository.Exists(user.UserId).Result) throw new UserExistsException(user.UserId);
        }
        #endregion
    }
}