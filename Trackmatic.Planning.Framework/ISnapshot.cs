using System.Collections.Generic;

namespace Trackmatic.Planning.Framework
{
    public interface ISnapshot<T> where T : IVersionSnapshot
    {
        string Id { get; set; }

        List<T> Versions { get; set; }
    }
}
