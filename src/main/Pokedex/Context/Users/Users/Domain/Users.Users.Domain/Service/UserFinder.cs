using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Exceptions;

namespace Users.Users.Domain.Service
{
    public class UserFinder
    {
        private UserRepository _userRepository;

        public UserFinder(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Execute(string userId)
        {
            var user = _userRepository.Find(userId);
            GuardUserNotFound(user);
            return user;
        }

        private void GuardUserNotFound(User user)
        {
            if (user == null) throw new UserNotFoundException();
        }
    }
}