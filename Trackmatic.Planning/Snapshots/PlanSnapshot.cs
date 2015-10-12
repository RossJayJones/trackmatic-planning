using System.Collections.Generic;
using Trackmatic.Planning.Framework;

namespace Trackmatic.Planning.Snapshots
{
    public class PlanVersionableSnapshot : IVersionableSnapshot<PlanVersionSnapshot>
    {
        public string Id { get; set; }

        public List<Status<EPlanStatus>> Status { get; set; }

        public List<PlanVersionSnapshot> Versions { get; set; }
    }
}
