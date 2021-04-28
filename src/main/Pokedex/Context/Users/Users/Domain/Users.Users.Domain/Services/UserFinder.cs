using System.Threading.Tasks;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Exceptions;
using Users.Users.Domain.Repositories;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Services
{
    public class UserFinder
    {
        private UserRepository _userRepository;

        public UserFinder(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Execute(UserId userId)
        {
            GuardUserNotFound(userId);
            return await _userRepository.Find(userId);
        }

        private void GuardUserNotFound(UserId userId)
        {
            if (!_userRepository.Exists(userId).Result) throw new UserNotFoundException(userId);
        }
    }
}