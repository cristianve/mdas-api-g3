using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Service;
using Users.Users.Domain.Test.ValueObject;
using Xunit;

namespace Users.Users.Application.Test.UseCase
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
    }
}
