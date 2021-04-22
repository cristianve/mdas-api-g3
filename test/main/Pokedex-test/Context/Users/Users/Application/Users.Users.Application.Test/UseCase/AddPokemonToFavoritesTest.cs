using Moq;
using System.Threading.Tasks;
using Users.Users.Application.UseCase;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Service;
using Users.Users.Domain.Test.ValueObject;
using Users.Users.Domain.ValueObject;
using Xunit;

namespace Users.Users.Application.Test.UseCase
{
    public class AddPokemonToFavoritesTest
    {
        [Fact]
        public async Task AddPokemonToFavorites_ReturnsPokemonFavorite()
        {
            #region Arrange
            string pokemonName = PokemonFavoriteMother.PokemonName();
            string userId = UserIdMother.Id();
            var userRepository = new Mock<UserRepository>();

            userRepository
                .Setup(r => r.AddFavorite(It.IsAny<User>()))
                .ReturnsAsync(new PokemonFavorite
                {
                    PokemonName = pokemonName
                });

            PokemonFavoriteCreator pokemonFavoriteCreator = new PokemonFavoriteCreator(userRepository.Object);
            AddPokemonToFavorites addPokemonToFavorites = new AddPokemonToFavorites(pokemonFavoriteCreator);

            #endregion

            #region Act
            PokemonFavorite pokemonFavorite = await addPokemonToFavorites.Execute(userId, pokemonName);

            #endregion

            #region Assert
            Assert.Equal(pokemonFavorite.PokemonName, pokemonName);

            #endregion
        }

        [Fact]
        public async Task AddPokemonToFavorite_ValidPokemonName_AddedToRepository()
        {
            #region Arrange
            string pokemonName = PokemonFavoriteMother.PokemonName();
            string userId = UserIdMother.Id();

            var userRepository = new Mock<UserRepository>();
 
            userRepository
                .Setup(r => r.AddFavorite(It.IsAny<User>()));

            PokemonFavoriteCreator pokemonFavoriteCreator = new PokemonFavoriteCreator(userRepository.Object);
            AddPokemonToFavorites addPokemonToFavorites = new AddPokemonToFavorites(pokemonFavoriteCreator);

            #endregion

            #region Act
            await addPokemonToFavorites.Execute(userId, pokemonName);

            #endregion

            #region Assert
            userRepository.Verify(r => r.AddFavorite(It.IsAny<User>()), Times.Once());

            #endregion
        }
    }
}
