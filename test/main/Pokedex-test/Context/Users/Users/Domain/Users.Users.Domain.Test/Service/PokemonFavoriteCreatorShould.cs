using System;
using System.Threading.Tasks;
using Moq;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Exceptions;
using Users.Users.Domain.Service;
using Users.Users.Domain.Test.ValueObject;
using Xunit;

namespace Users.Users.Domain.Test.Service
{
    public class PokemonFavoriteCreatorShould
    {
        [Fact]
        public async Task ShouldCreatePokemonFavorite()
        {
            #region Given

            string pokemonName = PokemonFavoriteMother.PokemonName();
            string userId = UserIdMother.Id();
            User user = new User(userId, pokemonName);
            var userRepository = new Mock<UserRepository>();

            userRepository
                .Setup(r => r.AddFavorite(It.IsAny<User>()));

            PokemonFavoriteCreator pokemonFavoriteCreator = new PokemonFavoriteCreator(userRepository.Object);

            #endregion

            #region When

            await pokemonFavoriteCreator.Execute(user);

            #endregion

            #region Then

            userRepository.Verify(r => r.AddFavorite(It.IsAny<User>()), Times.Once());

            #endregion
        }

        [Fact]
        public async Task ShouldShowErrorIfPokemonFavoriteExists()
        {
            #region Given

            string pokemonName = PokemonFavoriteMother.PokemonName();
            string userId = UserIdMother.Id();

            //new User(userId, pokemonName);
            User user = new User(userId, pokemonName);

            var userRepository = new Mock<UserRepository>();

            userRepository
                .Setup(r => r.AddFavorite(It.IsAny<User>()));

            PokemonFavoriteCreator pokemonFavoriteCreator = new PokemonFavoriteCreator(userRepository.Object);

            #endregion

            #region When

            await pokemonFavoriteCreator.Execute(user);

            var result = await pokemonFavoriteCreator.Execute(user);

            var exception = Record.ExceptionAsync(async () => await pokemonFavoriteCreator.Execute(user));

            #endregion

            #region Then

            Assert.Equal(typeof(PokemonFavoriteExistsException), exception.GetType());

            #endregion
        }
    }
}