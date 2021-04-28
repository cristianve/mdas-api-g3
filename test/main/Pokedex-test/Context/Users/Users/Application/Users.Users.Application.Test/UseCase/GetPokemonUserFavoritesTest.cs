using Moq;
using System.Linq;
using System.Threading.Tasks;
using Users.Users.Application.UseCase;
using Users.Users.Domain.Repositories;
using Users.Users.Domain.Services;
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
            string id = UserIdMother.Id();
            UserId userId = UserIdMother.UserId();
            string pokemonName = PokemonNameMother.Name();
            PokemonFavorites pokemonFavorites = PokemonFavoritesMother.PokemonFavorites();

            var userRepository = new Mock<UserRepository>();

            userRepository
                .Setup(r => r.Find(It.IsAny<UserId>()))
                .ReturnsAsync(UserMother.UserWithFavorites(id, pokemonName));

            userRepository
                .Setup(r => r.Exists(It.IsAny<UserId>()))
                .ReturnsAsync(true);

            UserFinder userFinder = new UserFinder(userRepository.Object);
            PokemonFavoriteSearcher pokemonFavoriteSearcher = new PokemonFavoriteSearcher();
            GetPokemonUserFavorites getPokemonUserFavorites = new GetPokemonUserFavorites(userFinder, pokemonFavoriteSearcher);

            #endregion

            #region Act
            PokemonFavorites favorites = await getPokemonUserFavorites.Execute(id);

            #endregion

            #region Assert
            Assert.True(pokemonFavorites.Favorites.All(f => favorites.Favorites.Any(item =>
                item.PokemonName.Name == f.PokemonName.Name)));

            #endregion
        }
    }
}
