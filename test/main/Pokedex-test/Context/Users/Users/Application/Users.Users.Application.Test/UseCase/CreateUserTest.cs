using Moq;
using System.Threading.Tasks;
using Users.Users.Application.UseCase;
using Users.Users.Domain.Aggregate;
using Users.Users.Domain.Service;
using Users.Users.Domain.Test.Aggregate;
using Users.Users.Domain.Test.ValueObject;
using Users.Users.Domain.ValueObject;
using Xunit;

namespace Users.Users.Application.Test.UseCase
{
    public class CreateUserTest
    {
        [Fact]
        public async Task CreateUser_ReturnsVoid()
        {
            #region Arrange
            string userId = UserIdMother.Id();
            var userRepository = new Mock<UserRepository>();

            userRepository
                .Setup(r => r.Save(It.IsAny<User>()));

            UserCreator userCreator = new UserCreator(userRepository.Object);
            CreateUser createUser = new CreateUser(userCreator);

            #endregion

            #region Act
            await createUser.Execute(userId);

            #endregion

            #region Assert
            userRepository.Verify(r => r.Save(It.IsAny<User>()), Times.Once());
            #endregion
        }

        [Fact]
        public void CreateUser_ReturnsUserAlreadyExistsException()
        {
            #region Arrange
            string userId = UserIdMother.Id();
            string expectedMessage = $"The user '{userId}' already exists";

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
            CreateUser createUser = new CreateUser(userCreator);

            #endregion

            #region Act
            var exception = Record.ExceptionAsync(async () => await createUser.Execute(userId));

            #endregion

            #region Assert
            Assert.Equal(expectedMessage, exception.Result.Message);

            #endregion
        }
    }
}
