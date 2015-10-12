using Trackmatic.Common.Model;

namespace Trackmatic.Planning.Framework
{
    public interface IVersionSnapshot
    {
        VersionSnapshot Version { get; set; }
    }
}
