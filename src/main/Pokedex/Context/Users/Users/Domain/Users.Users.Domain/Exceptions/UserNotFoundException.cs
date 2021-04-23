using System;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        private UserId _userId;

        public override string Message
            => $"User '{_userId.Id}' does not exists";

        public UserNotFoundException(UserId userId)
        {
            _userId = userId;
        }
    }
}