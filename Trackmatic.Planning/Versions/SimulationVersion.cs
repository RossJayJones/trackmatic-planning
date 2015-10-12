using System.Collections.Generic;
using Trackmatic.Common.Model;
using Trackmatic.Planning.Framework;
using Trackmatic.Planning.Snapshots;

namespace Trackmatic.Planning.Versions
{
    public class SimulationVersion : IVersion<SimulationVersion>, IStorableVersion<SimulationVersionSnapshot>
    {
        private readonly Version _version;

        private readonly List<Run> _runs;

        private readonly ReadonlyMixin _readonly;

        private SimulationVersion(SimulationVersionSnapshot snapshot, UserReference user) : this(snapshot)
        {
            _version = _version.Increment(user);
            _readonly = new ReadonlyMixin(false);
        }

        public SimulationVersion(SimulationVersionSnapshot snapshot)
        {
            _version = new Version(snapshot.Version);
            _runs = snapshot.Runs;
            _readonly = new ReadonlyMixin(true);

        }

        public SimulationVersion(Version version)
        {
            _version = version;
            _runs = new List<Run>();
        }

        public Version Version => _version;

        public IEnumerable<Run> Runs => _runs;

        public SimulationVersion Edit(UserReference user)
        {
            var snapshot = CreateSnapshot();
            var clone = snapshot.Clone(user);
            return new SimulationVersion(clone, user);
        }

        public Version Current => _version;

        public SimulationVersionSnapshot CreateSnapshot()
        {
            var snapshot = new SimulationVersionSnapshot
            {
                Version = new VersionSnapshot(_version),
                Runs = _runs
            };
            return snapshot;
        }

        public void Add(Run run)
        {
            _readonly.Guard();
            _runs.Add(run);
        }
    }
}
