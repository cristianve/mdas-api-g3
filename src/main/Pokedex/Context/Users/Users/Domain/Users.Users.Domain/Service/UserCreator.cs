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

        public void Execute(User user)
        {
            GuardUserExists(user);
            _userRepository.Save(user);
        }

        private void GuardUserExists(User user)
        {
            if (_userRepository.Find(user.UserId.Id) != null)
            {
                throw new UserExistsException();
            }
        }
    }
}