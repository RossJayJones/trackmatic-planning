using System.Collections.Generic;
using Trackmatic.Common.Model;
using Trackmatic.Planning.Framework;

namespace Trackmatic.Planning.Snapshots
{
    public class SimulationVersionSnapshot : IVersionSnapshot
    {
        private readonly CloneMixin<SimulationVersionSnapshot> _clone;
        public SimulationVersionSnapshot()
        {
            _clone = new CloneMixin<SimulationVersionSnapshot>(this);
        }

        public VersionSnapshot Version { get; set; }

        public List<Run> Runs { get; set; }

        public SimulationVersionSnapshot Clone(UserReference user)
        {
            return _clone.Clone(user);
        }
    }
}
