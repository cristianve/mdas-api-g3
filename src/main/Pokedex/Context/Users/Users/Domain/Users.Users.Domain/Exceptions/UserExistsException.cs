using System;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Exceptions
{
    public class UserExistsException : Exception
    {
        private UserId _userId;
        public override string Message => $"The user '{ _userId.Id }' already exists";

        public UserExistsException(UserId userId)
        {
            _userId = userId;
        }
    }
}