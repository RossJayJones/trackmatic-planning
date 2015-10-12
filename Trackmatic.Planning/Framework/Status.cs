using System;

namespace Trackmatic.Planning.Framework
{
    public class Status<T>
    {
        public Status()
        {
            Timestamp = DateTime.UtcNow;
        }

        public T Previous { get; set; }

        public T Current { get; set; }

        public UserReference User { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
