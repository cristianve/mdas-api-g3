using Users.Users.Domain.Exceptions;

namespace Users.Users.Domain.ValueObject
{
    public class UserId
    {
        public string Id { get; }

        public UserId(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new InvalidUserException();
            }

            Id = id;
        }
    }
}
