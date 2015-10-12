using Newtonsoft.Json;
using Trackmatic.Common.Model;

namespace Trackmatic.Planning.Framework
{
    public class CloneMixin<T> where T : IVersionSnapshot
    {
        private readonly IVersionSnapshot _snapshot;
        public CloneMixin(IVersionSnapshot snapshot)
        {
            _snapshot = snapshot;
        }

        public T Clone(UserReference user)
        {
            var json = JsonConvert.SerializeObject(_snapshot);
            var clone = JsonConvert.DeserializeObject<T>(json);
            return clone;
        }
    }
}
