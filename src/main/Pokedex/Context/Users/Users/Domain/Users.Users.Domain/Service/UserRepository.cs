using System.Threading.Tasks;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Service
{
    public interface UserRepository
    {
        public Task Save(User user);
        public Task<User> Find(UserId userId);
        public Task<bool> Exists(UserId userId);
    }
}