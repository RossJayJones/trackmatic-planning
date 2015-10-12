using System;
using Trackmatic.Common.Model;

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

        public Version(VersionSnapshot snapshot)
        {
            Id = snapshot.Id;
            Timestamp = snapshot.Timestamp;
            User = snapshot.User;
        }

        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public UserReference User { get; set; }

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
