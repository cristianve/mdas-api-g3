using System;

namespace Shared.Domain.Exceptions
{
    public class HttpNotFoundException : Exception
    {
        public HttpNotFoundException(string message) : base(message)
        {
        }
    }
}
