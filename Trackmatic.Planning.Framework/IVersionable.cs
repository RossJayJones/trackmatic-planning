using Trackmatic.Common.Model;

namespace Trackmatic.Planning.Framework
{
    public interface IVersionable<out T> where T : IVersion<T>
    {
        T Edit(UserReference user);

        T GetCurrentVersion();

        int Version { get; }
    }
}
