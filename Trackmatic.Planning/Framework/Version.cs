using System;

namespace Trackmatic.Planning.Framework
{
    public class Version
    {
        public Version()
        {
            
        }

        public Version(UserReference user)
        {
            User = user;
            Timestamp = DateTime.UtcNow;
        }

        public int Id { get; private set; }

        public DateTime Timestamp { get; private set; }

        public UserReference User { get; private set; }

        public Version Increment(UserReference user)
        {
            var next = new Version(user)
            {
                Id = Id + 1
            };
            return next;
        }

        public override string ToString()
        {
            return $"{Timestamp}: {Id}";
        }
    }
}
