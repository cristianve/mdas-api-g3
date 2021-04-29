using System;

namespace Shared.Domain.Exceptions
{
    public class HttpException : Exception
    {
        public override string Message
            => $"An error occurred in the connection of the api";
    }
}
