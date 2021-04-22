using Users.Users.Domain.Aggregate;

namespace Users.Users.Domain.Service
{
    public interface UserRepository
    {
        public void Save(User user);
        public User Find(string userId);
    }
}