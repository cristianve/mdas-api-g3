using System.Threading.Tasks;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Service;

namespace Users.Users.Application.UseCase
{
    public class CreateUser
    {
        private readonly UserCreator _userCreator;

        public CreateUser(UserCreator userCreator)
        {
            _userCreator = userCreator;
        }

        public async Task Execute(string userId)
        {
            await _userCreator.Execute(User.Create(userId));
        }
    }
}