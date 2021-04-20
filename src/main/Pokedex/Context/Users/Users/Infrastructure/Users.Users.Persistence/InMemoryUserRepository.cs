using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Threading.Tasks;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Service;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Persistence
{
    public class InMemoryUserRepository : UserRepository
    {
        private readonly IMemoryCache _memoryCache;
        private const string CACHE_KEY_PREFIX = "user/";

        public InMemoryUserRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<PokemonFavorite> AddFavorite(User user)
        {
            var cacheKey = GetCacheKey(user.UserId.Id);
            User userFound = await FindUser(user);

            if (userFound != null)
            {
                userFound.PokemonFavorites.Add(user.PokemonFavorites.FirstOrDefault());
                _memoryCache.Set(cacheKey, userFound);
            }
            else
            {
                _memoryCache.Set(cacheKey, user);
            }
            
            return user.PokemonFavorites.FirstOrDefault();
        }

        public async Task<User> FindUser(User user)
        {
            var cacheKey = GetCacheKey(user.UserId.Id);

            if (_memoryCache.TryGetValue(cacheKey, out User userFound))
                return userFound;

            return null;
        }

        public async Task<bool> FavoriteExistsInUser(User user)
        {
            User userFound = await FindUser(user);

            if (userFound == null)
            {
                return false;
            }

            return userFound.PokemonFavorites.Where(q => q.PokemonName == user.PokemonFavorites.FirstOrDefault().PokemonName).Count() > 0 ? true : false;
        }

        private string GetCacheKey(string key)
        {
            return CACHE_KEY_PREFIX + key;
        }
    }
}
