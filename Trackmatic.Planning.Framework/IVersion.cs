using Trackmatic.Common.Model;

namespace Trackmatic.Planning.Framework
{
    public interface IVersion<out T>
    {
        T Edit(UserReference user);

        VersionData Version { get; }
    }
}
