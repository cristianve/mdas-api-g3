using System;

namespace Users.Users.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public override string Message
            => $"User does not exists";
    }
}