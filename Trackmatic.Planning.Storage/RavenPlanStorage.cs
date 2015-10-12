using Raven.Client;
using Trackmatic.Planning.Framework;
using Trackmatic.Planning.Snapshots;

namespace Trackmatic.Planning.Storage
{
    public class RavenPlanStorage : IStorage<Plan>
    {
        private readonly IDocumentStore _store;
        public RavenPlanStorage(IDocumentStore store)
        {
            _store = store;
        }

        public void Store(Plan item)
        {
            using (var session = CreateSession())
            {
                var snapshot = item.CreateSnapshot();
                session.Store(snapshot);
                session.SaveChanges();
            }
        }

        public Plan Get(string id)
        {
            using (var session = CreateSession())
            {
                var snapshot = session.Load<PlanVersionableSnapshot>(id);
                return new Plan(snapshot);
            }
        }

        private IDocumentSession CreateSession()
        {
            return _store.OpenSession("trackmatic-planning");
        }
    }
}
