using System;

namespace Users.Users.Domain.Exceptions
{
    public class InvalidUserException : Exception
    {
        public override string Message => $"Invalid user";
    }
}