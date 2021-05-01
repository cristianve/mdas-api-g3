using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Entities;
using Users.Users.Domain.Test.ValueObject;
using Users.Users.Domain.ValueObject;
using Users.Users.Persistence;
using Xunit;

namespace Pokemons.Types.Persistence.Test
{
    public class InMemoryUserRepositoryTest
    {
        private readonly IMemoryCache memoryCache;

        public InMemoryUserRepositoryTest()
        {
            var services = new ServiceCollection();
            services.AddMemoryCache();
            var serviceProvider = services.BuildServiceProvider();

            memoryCache = serviceProvider.GetService<IMemoryCache>();
        }

        [Fact]
        public async Task SaveUser_ReturnsUser()
        {
            #region Arrange

            InMemoryUserRepository inMemoryUserRepository = new InMemoryUserRepository(memoryCache);
            UserId userId = new UserId(UserIdMother.Id());
            User user = new User(userId);
            #endregion

            #region Act
            await inMemoryUserRepository.Save(user);
            User userFound = await inMemoryUserRepository.Find(userId);

            #endregion

            #region Assert
            Assert.Equal(userFound.UserId.Id, userId.Id);

            #endregion
        }

        [Fact]
        public async Task SearchUser_Found_ReturnsUser()
        {
            #region Arrange
            
            InMemoryUserRepository inMemoryUserRepository = new InMemoryUserRepository(memoryCache);
            UserId userId = new UserId(UserIdMother.Id());
            User user = new User(userId);
            #endregion

            #region Act
            await inMemoryUserRepository.Save(user);
            User userFound = await inMemoryUserRepository.Find(userId);

            #endregion

            #region Assert
            Assert.Equal(userFound.UserId.Id, userId.Id);

            #endregion
        }

        [Fact]
        public async Task ExistsUser_ReturnsBool()
        {
            #region Arrange

            InMemoryUserRepository inMemoryUserRepository = new InMemoryUserRepository(memoryCache);
            UserId userId = new UserId(UserIdMother.Id());
            User user = new User(userId);
            #endregion

            #region Act
            await inMemoryUserRepository.Save(user);
            bool exists = await inMemoryUserRepository.Exists(userId);

            #endregion

            #region Assert
            Assert.True(exists);

            #endregion
        }

        [Fact]
        public async Task SaveFavorites_ReturnsUserWithFavorites()
        {
            #region Arrange

            InMemoryUserRepository inMemoryUserRepository = new InMemoryUserRepository(memoryCache);
            UserId userId = new UserId(UserIdMother.Id());
            User user = new User(userId);
            PokemonId pokemonId = PokemonIdMother.PokemonId();
            user.AddPokemonFavorite(new PokemonFavorite(pokemonId));

            #endregion

            #region Act
            await inMemoryUserRepository.Save(user);
            User userFound = await inMemoryUserRepository.Find(userId);
            await inMemoryUserRepository.SaveFavorites(user);

            #endregion

            #region Assert
            var pokemonFavoritesArray = userFound.PokemonFavorites.Favorites.Select(s => s.PokemonId.Id.ToString()).ToArray();
            Assert.Equal(pokemonFavoritesArray, PokemonFavoritesMother.PokemonFavorites().Favorites.Select(s => s.PokemonId.Id.ToString()).ToArray(), StringComparer.InvariantCultureIgnoreCase);

            #endregion
        }

        [Fact]
        public async Task SearchUser_Found_ReturnsUserWithFavorites()
        {
            #region Arrange

            InMemoryUserRepository inMemoryUserRepository = new InMemoryUserRepository(memoryCache);
            UserId userId = new UserId(UserIdMother.Id());
            User user = new User(userId);
            PokemonId pokemonId = PokemonIdMother.PokemonId();
            user.AddPokemonFavorite(new PokemonFavorite(pokemonId));

            #endregion

            #region Act
            await inMemoryUserRepository.Save(user);
            User userFound = await inMemoryUserRepository.Find(userId);
            await inMemoryUserRepository.SaveFavorites(user);

            #endregion

            #region Assert
            var pokemonFavoritesArray = userFound.PokemonFavorites.Favorites.Select(s => s.PokemonId.Id.ToString()).ToArray();
            Assert.Equal(userFound.UserId.Id, userId.Id);
            Assert.Equal(pokemonFavoritesArray, PokemonFavoritesMother.PokemonFavorites().Favorites.Select(s => s.PokemonId.Id.ToString()).ToArray(), StringComparer.InvariantCultureIgnoreCase);

            #endregion
        }

        [Fact]
        public async Task SearchUser_NotFound_ReturnsNull()
        {
            #region Arrange

            InMemoryUserRepository inMemoryUserRepository = new InMemoryUserRepository(memoryCache);
            UserId userId = new UserId(UserIdMother.Id());
            #endregion

            #region Act
            User userFound = await inMemoryUserRepository.Find(userId);

            #endregion

            #region Assert
            Assert.Null(userFound);

            #endregion
        }
    }
}
