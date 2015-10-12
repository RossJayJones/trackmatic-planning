using System;
using System.Collections.Generic;
using System.Linq;
using Trackmatic.Common.Model;

namespace Trackmatic.Planning.Framework
{
    public class StatusMixin<T> : ITrackStatusChanges<T>
    {
        private readonly List<Status<T>> _status;

        public StatusMixin(IEnumerable<Status<T>> status)
        {


            _status = status?.ToList() ?? new List<Status<T>> { new Status<T>()};
        }

        public StatusMixin(T initialStatus, UserReference user) : this(new Status<T>
        {
            Current = initialStatus,
            Previous = initialStatus,
            User = user
        })
        {
            
        }
        public StatusMixin(Status<T> initialStatus)
        {
            _status = new List<Status<T>> {initialStatus};
        }
        public IEnumerable<Status<T>> Status => _status;

        public T GetCurrentStatus()
        {
            return _status[0].Current;
        }

        public void Set(T status, UserReference user)
        {
            if (GetCurrentStatus().Equals(status))
            {
                return;
            }

            var change = new Status<T>
            {
                Previous = GetCurrentStatus(),
                Current = status,
                Timestamp = DateTime.UtcNow,
                User = user
            };

            _status.Insert(0, change);
        }
    }
}
