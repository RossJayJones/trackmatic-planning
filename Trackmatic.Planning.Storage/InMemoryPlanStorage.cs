using System.Collections.Generic;
using Trackmatic.Planning.Framework;
using Trackmatic.Planning.Snapshots;

namespace Trackmatic.Planning.Storage
{
    public class InMemoryPlanStorage : IStorage<Plan>
    {
        private readonly Dictionary<string, PlanVersionableSnapshot> _storage;

        public InMemoryPlanStorage()
        {
            _storage = new Dictionary<string, PlanVersionableSnapshot>();
        }
        
        public void Store(Plan item)
        {
            var snapshot = item.CreateSnapshot();
            if (!_storage.ContainsKey(snapshot.Id))
            {
                _storage.Add(snapshot.Id, snapshot);
            }
            _storage[snapshot.Id] = snapshot;
        }

        public Plan Get(string id)
        {
            var snapshot = _storage[id];
            return new Plan(snapshot);
        }
    }
}
