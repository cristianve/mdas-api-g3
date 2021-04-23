using System;
using System.Threading.Tasks;
using Moq;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Exceptions;
using Users.Users.Domain.Service;
using Users.Users.Domain.Test.Aggregate;
using Users.Users.Domain.Test.ValueObject;
using Users.Users.Domain.ValueObject;
using Xunit;

namespace Users.Users.Domain.Test.Service
{
    public class PokemonFavoriteCreatorShould
    {
        [Fact]
        public async Task ShouldCreatePokemonFavorite()
        {
            #region Given

            PokemonName pokemonName = PokemonNameMother.PokemonName();
            string userId = UserIdMother.Id();
            User user = new User(userId);
            var userRepository = new Mock<UserRepository>();

            userRepository
                .Setup(r => r.SaveFavorites(It.IsAny<User>()));

            PokemonFavoriteCreator pokemonFavoriteCreator = new PokemonFavoriteCreator(userRepository.Object);

            #endregion

            #region When

            await pokemonFavoriteCreator.Execute(user, pokemonName);

            #endregion

            #region Then

            userRepository.Verify(r => r.SaveFavorites(It.IsAny<User>()), Times.Once());

            #endregion
        }

        [Fact]
        public void ShouldThrowAnExceptionWhenPokemonFavoriteAlreadyExists()
        {
            #region Given

            PokemonName pokemonName = PokemonNameMother.PokemonName();
            string userId = UserIdMother.Id();
            string expectedMessage = $"The pokemon '{pokemonName.Name}' already exists in user favorites list";
            User user = UserMother.UserWithFavorites(userId, pokemonName.Name);

            var userRepository = new Mock<UserRepository>();

            userRepository
                .Setup(r => r.Find(It.IsAny<UserId>()))
                .ReturnsAsync(UserMother.UserWithFavorites(userId, pokemonName.Name));

            userRepository
                .Setup(r => r.SaveFavorites(It.IsAny<User>()));

            PokemonFavoriteCreator pokemonFavoriteCreator = new PokemonFavoriteCreator(userRepository.Object);

            #endregion

            #region When
            var exception = Record.ExceptionAsync(async () => await pokemonFavoriteCreator.Execute(user, pokemonName));

            #endregion

            #region Then
            Assert.Equal(expectedMessage, exception.Result.Message);

            #endregion
        }
    }
}