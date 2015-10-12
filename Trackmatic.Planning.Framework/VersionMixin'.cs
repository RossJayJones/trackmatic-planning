using System.Collections.Generic;
using System.Linq;
using Trackmatic.Common.Model;

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

        public T Edit(UserReference user)
        {
            var current = GetCurrentVersion();
            var next = current.Edit(user);
            _versions.Insert(0, next);
            return next;
        }

        public T GetCurrentVersion()
        {
            return _versions[0];
        }

        public int Version => GetCurrentVersion().Version.Id;
    }
}
