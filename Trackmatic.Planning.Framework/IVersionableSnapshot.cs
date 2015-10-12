using System.Collections.Generic;

namespace Trackmatic.Planning.Framework
{
    public interface IVersionableSnapshot
    {
        string Id { get; set; }
    }

    public interface IVersionableSnapshot<T> : IVersionableSnapshot where T : IVersionSnapshot
    {
        List<T> Versions { get; set; }
    }
}
