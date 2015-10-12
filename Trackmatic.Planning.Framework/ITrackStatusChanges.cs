using System.Collections.Generic;
using Trackmatic.Common.Model;

namespace Trackmatic.Planning.Framework
{
    public interface ITrackStatusChanges<T>
    {
        T GetCurrentStatus();

        void Set(T status, UserReference user);
    }
}
