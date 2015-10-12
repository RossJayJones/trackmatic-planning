using System.Collections.Generic;

namespace Trackmatic.Planning.Framework
{
    public interface IVersionable<out T> where T : IVersion<T>
    {
        IEnumerable<T> Versions { get; }

        void Edit(UserReference user);

        T GetCurrentVersion();
    }
}
