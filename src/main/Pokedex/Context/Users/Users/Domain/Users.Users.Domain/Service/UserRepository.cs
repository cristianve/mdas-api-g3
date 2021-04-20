using System.Threading.Tasks;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Service
{
    public interface UserRepository
    {
        Task<PokemonFavorite> AddFavorite(User user);
        Task<User> FindUser(User user);
        Task<bool> FavoriteExistsInUser(User user);
    }
}
