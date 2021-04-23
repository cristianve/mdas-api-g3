using System.Threading.Tasks;
using Moq;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Service;
using Users.Users.Domain.Test.Aggregate;
using Users.Users.Domain.Test.ValueObject;
using Users.Users.Domain.ValueObject;
using Xunit;

namespace Users.Users.Domain.Test.Service
{
    public class UserCreatorShould
    {
        [Fact]
        public async Task ShouldCreateUser()
        {
            #region Given
            string userId = UserIdMother.Id();
            User user = UserMother.User(userId);
            var userRepository = new Mock<UserRepository>();
            
            userRepository
                .Setup(r => r.Save(It.IsAny<User>()));

            UserCreator userCreator = new UserCreator(userRepository.Object);

            #endregion

            #region When

            await userCreator.Execute(user);

            #endregion

            #region Then

            userRepository.Verify(r => r.Save(It.IsAny<User>()), Times.Once());

            #endregion
        }

        [Fact]
        public void ShouldThrowAnExceptionWhenUserAlreadyExists()
        {
            #region Given

            string userId = UserIdMother.Id();
            string expectedMessage = $"The user '{userId}' already exists";
            User user = UserMother.User(userId);

            var userRepository = new Mock<UserRepository>();

            userRepository
                .Setup(r => r.Find(It.IsAny<UserId>()))
                .ReturnsAsync(UserMother.User(userId));

            userRepository
                .Setup(r => r.Exists(It.IsAny<UserId>()))
                .ReturnsAsync(true);

            userRepository
                .Setup(r => r.Save(It.IsAny<User>()));

            UserCreator userCreator = new UserCreator(userRepository.Object);

            #endregion

            #region When
            var exception = Record.ExceptionAsync(async () => await userCreator.Execute(user));

            #endregion

            #region Then
            Assert.Equal(expectedMessage, exception.Result.Message);

            #endregion
        }
    }
}