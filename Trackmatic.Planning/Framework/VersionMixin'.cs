using System.Collections.Generic;
using System.Linq;

namespace Trackmatic.Planning.Framework
{
    public sealed class VersionMixin<T> : IVersionable<T> where T : IVersion<T>
    {
        private readonly List<T> _versions;

        public VersionMixin(IEnumerable<T> versions)
        {
            _versions = versions.ToList();
        }

        public VersionMixin(T initialVersion) : this(new List<T> {  initialVersion})
        {

        }

        public IEnumerable<T> Versions => _versions;

        public void Edit(UserReference user)
        {
            var next = GetCurrentVersion().Edit(user);
            _versions.Insert(0, next);
        }

        public T GetCurrentVersion()
        {
            return _versions[0];
        }
    }
}
