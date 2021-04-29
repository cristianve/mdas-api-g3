using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Repositories;
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

        public async Task Save(User user)
        {
            var cacheKey = GetCacheKey(user.UserId.Id);

            User userFound = await Find(user.UserId);

            _memoryCache.Set(cacheKey, userFound ?? user);
        }

        public async Task<User> Find(UserId userId)
        {
            var cacheKey = GetCacheKey(userId.Id);
            return _memoryCache.TryGetValue(cacheKey, out User userFound) ? userFound : null;
        }

        public async Task<bool> Exists(UserId userId)
        {
            var cacheKey = GetCacheKey(userId.Id);

            return _memoryCache.TryGetValue(cacheKey, out User userFound) ? true : false;
        }

        public async Task SaveFavorites(User user)
        {
            var cacheKey = GetCacheKey(user.UserId.Id);
            User userFound = await Find(user.UserId);
            _memoryCache.Set(cacheKey, userFound);
        }

        #region private methods
        private string GetCacheKey(string key)
        {
            return CACHE_KEY_PREFIX + key;
        }

        #endregion
    }
}