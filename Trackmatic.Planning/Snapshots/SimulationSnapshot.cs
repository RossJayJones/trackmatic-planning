using System.Collections.Generic;
using Trackmatic.Planning.Framework;

namespace Trackmatic.Planning.Snapshots
{
    public class SimulationSnapshot : ISnapshot<SimulationVersionSnapshot>
    {
        public string Id { get; set; }

        public List<SimulationVersionSnapshot> Versions { get; set; }

        public List<Status<ESimulationStatus>> Status { get; set; }
    }
}