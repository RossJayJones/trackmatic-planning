using System.Collections.Generic;

namespace Trackmatic.Planning.Framework
{
    public interface ITrackStatusChanges<T>
    {
        T GetCurrentStatus();

        void Set(T status, UserReference user);

        IEnumerable<Status<T>> Status { get; } 
    }
}
