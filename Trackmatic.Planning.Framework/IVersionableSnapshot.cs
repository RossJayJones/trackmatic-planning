using System.Collections.Generic;

namespace Trackmatic.Planning.Framework
{
    public interface IVersionableSnapshot<T> where T : IVersionSnapshot
    {
        string Id { get; set; }

        List<T> Versions { get; set; }
    }
}
