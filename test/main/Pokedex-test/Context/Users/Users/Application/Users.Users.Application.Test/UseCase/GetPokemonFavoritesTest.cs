using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Users.Application.UseCase;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Entities;
using Users.Users.Domain.Service;
using Users.Users.Domain.Test.ValueObject;
using Xunit;

namespace Users.Users.Application.Test.UseCase
{
    public class GetPokemonFavoritesTest
    {
        [Fact]
        public async Task GetPokemonFavorites_ReturnsPokemonFavorites()
        {
            #region Arrange
            string userId = UserIdMother.Id();
            string pokemonFavorite = PokemonFavoriteMother.PokemonName();
            List<PokemonFavorite> pokemonFavorites = PokemonFavoriteMother.PokemonFavorites();

            var userRepository = new Mock<UserRepository>();

            userRepository
                .Setup(r => r.FindUserWithFavorites(It.IsAny<User>()))
                .ReturnsAsync(new User(
                    userId,
                    pokemonFavorite
                    ));

            PokemonFavoriteSearcher pokemonFavoriteSearcher = new PokemonFavoriteSearcher(userRepository.Object);
            GetPokemonFavorites getPokemonFavorites = new GetPokemonFavorites(pokemonFavoriteSearcher);

            #endregion

            #region Act
            List<PokemonFavorite> favorites = await getPokemonFavorites.Execute(userId);

            #endregion

            #region Assert
            Assert.True(pokemonFavorites.All(f => favorites.Any(item =>
                item.PokemonName == f.PokemonName)));

            #endregion
        }
    }
}
