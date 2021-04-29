using System;
using System.Threading.Tasks;
using Moq;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Entities;
using Users.Users.Domain.Exceptions;
using Users.Users.Domain.Repositories;
using Users.Users.Domain.Services;
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
            PokemonFavorite pokemonFavorite = new PokemonFavorite(pokemonName);
            string userId = UserIdMother.Id();
            User user = new User(new UserId(userId));
            var userRepository = new Mock<UserRepository>();

            userRepository
                .Setup(r => r.SaveFavorites(It.IsAny<User>()));

            PokemonFavoriteCreator pokemonFavoriteCreator = new PokemonFavoriteCreator(userRepository.Object);

            #endregion

            #region When

            await pokemonFavoriteCreator.Execute(user, pokemonFavorite);

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
            PokemonFavorite pokemonFavorite = new PokemonFavorite(pokemonName);
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
            var exception = Record.ExceptionAsync(async () => await pokemonFavoriteCreator.Execute(user, pokemonFavorite));

            #endregion

            #region Then
            Assert.Equal(expectedMessage, exception.Result.Message);

            #endregion
        }
    }
}