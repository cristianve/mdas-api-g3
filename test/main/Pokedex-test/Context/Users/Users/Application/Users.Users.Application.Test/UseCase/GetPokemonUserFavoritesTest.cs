using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Users.Application.UseCase;
using Users.Users.Domain.Entities;
using Users.Users.Domain.Service;
using Users.Users.Domain.Test.Aggregate;
using Users.Users.Domain.Test.ValueObject;
using Users.Users.Domain.ValueObject;
using Xunit;

namespace Users.Users.Application.Test.UseCase
{
    public class GetPokemonUserFavoritesTest
    {
        [Fact]
        public async Task GetPokemonFavorites_ReturnsPokemonFavorites()
        {
            #region Arrange
            string userId = UserIdMother.Id();
            string pokemonName = PokemonNameMother.Name();
            List<PokemonFavorite> pokemonFavorites = PokemonNameMother.PokemonFavorites();

            var userRepository = new Mock<UserRepository>();

            userRepository
                .Setup(r => r.Find(It.IsAny<UserId>()))
                .ReturnsAsync(UserMother.UserWithFavorites(userId, pokemonName));

            userRepository
                .Setup(r => r.Exists(It.IsAny<UserId>()))
                .ReturnsAsync(true);

            UserFinder userFinder = new UserFinder(userRepository.Object);
            PokemonFavoriteSearcher pokemonFavoriteSearcher = new PokemonFavoriteSearcher();
            GetPokemonUserFavorites getPokemonUserFavorites = new GetPokemonUserFavorites(userFinder, pokemonFavoriteSearcher);

            #endregion

            #region Act
            List<PokemonFavorite> favorites = await getPokemonUserFavorites.Execute(userId);

            #endregion

            #region Assert
            Assert.True(pokemonFavorites.All(f => favorites.Any(item =>
                item.PokemonName.Name == f.PokemonName.Name)));

            #endregion
        }
    }
}
