using System;

namespace Users.Users.Domain.Exceptions
{
    public class UserExistsException : Exception
    {
        public override string Message => $"The user already exists";
    }
}