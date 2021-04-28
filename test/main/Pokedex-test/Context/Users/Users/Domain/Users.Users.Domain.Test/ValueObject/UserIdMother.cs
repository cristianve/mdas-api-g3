using System;
using System.Linq;
using Users.Users.Domain.ValueObject;

namespace Users.Users.Domain.Test.ValueObject
{
    public class UserIdMother
    {
        private static UserId _userId;
        private static string _id = "123456";
        private static Random random = new Random();
        private const int NUM_OF_CHARS = 8;

        public static string Random()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, NUM_OF_CHARS)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string Id()
        {
            return _id;
        }

        public static UserId UserId()
        {
            _userId = new UserId(_id);
            return _userId;
        }
    }
}
