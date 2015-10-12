using System.Collections.Generic;
using Trackmatic.Common.Model;
using Trackmatic.Planning.Framework;

namespace Trackmatic.Planning.Snapshots
{
    public class PlanVersionSnapshot : IVersionSnapshot
    {
        private CloneMixin<PlanVersionSnapshot> _clone;
        public PlanVersionSnapshot()
        {
            _clone = new CloneMixin<PlanVersionSnapshot>(this);
        }

        public VersionSnapshot Version { get; set; }


        public PlanVersionSnapshot Clone(UserReference user)
        {
            return _clone.Clone(user);
        }

        public string Name { get; set; }

        public Depot Depot { get; set; }

        public List<Action> Actions { get; set; }

        public List<Resource> Resources { get; set; }

        public List<SimulationSnapshot> Simulations { get; set; }
    }
}
