using System;
using Trackmatic.Common.Model;

namespace Trackmatic.Planning.Framework
{
    public class VersionData
    {
        public VersionData()
        {
            
        }

        public VersionData(UserReference user)
        {
            User = user;
            Timestamp = DateTime.UtcNow;
        }

        public VersionData(VersionDataSnapshot snapshot)
        {
            Id = snapshot.Id;
            Timestamp = snapshot.Timestamp;
            User = snapshot.User;
        }

        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public UserReference User { get; set; }

        public VersionData Increment(UserReference user)
        {
            var next = new VersionData(user)
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
