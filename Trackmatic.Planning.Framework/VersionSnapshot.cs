using System;
using Trackmatic.Common.Model;

namespace Trackmatic.Planning.Framework
{
    public class VersionSnapshot
    {
        public VersionSnapshot()
        {
            
        }

        public VersionSnapshot(Version version)
        {
            Id = version.Id;
            Timestamp = version.Timestamp;
            User = version.User;
        }

        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public UserReference User { get; set; }
    }
}
