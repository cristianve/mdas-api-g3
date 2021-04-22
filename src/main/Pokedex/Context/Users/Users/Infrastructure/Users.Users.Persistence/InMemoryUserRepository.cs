using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Service;

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

        public void Save(User user)
        {
            var cacheKey = GetCacheKey(user.UserId.Id);

            User userFound = Find(user.UserId.Id);

            _memoryCache.Set(cacheKey, userFound ?? user);
        }

        public User Find(string userId)
        {
            var cacheKey = GetCacheKey(userId);

            return _memoryCache.TryGetValue(cacheKey, out User userFound) ? userFound : null;
        }

        #region private methods

        private string GetCacheKey(string key)
        {
            return CACHE_KEY_PREFIX + key;
        }

        #endregion
    }
}