using System.Collections.Generic;
using Trackmatic.Planning.Framework;

namespace Trackmatic.Planning.Snapshots
{
    public class PlanVersionSnapshot : IVersionSnapshot
    {
        private readonly CloneMixin<PlanVersionSnapshot> _clone;

        public PlanVersionSnapshot()
        {
            _clone = new CloneMixin<PlanVersionSnapshot>(this);
        }

        public VersionDataSnapshot Version { get; set; }


        public PlanVersionSnapshot Clone()
        {
            return _clone.Clone();
        }

        public string Name { get; set; }

        public Depot Depot { get; set; }

        public List<Action> Actions { get; set; }

        //public List<Resource> Resources { get; set; }

        public List<ResourceType> ResourceTypes { get; set; }

        public List<SimulationVersionableSnapshot> Simulations { get; set; }
    }
}
