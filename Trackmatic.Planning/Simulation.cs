using Trackmatic.Planning.Framework;
using System.Linq;
using Trackmatic.Common.Model;
using Trackmatic.Planning.Snapshots;
using Trackmatic.Planning.Versions;

namespace Trackmatic.Planning
{
    public class Simulation : IVersionable<SimulationVersion>, ITrackStatusChanges<ESimulationStatus>
    {
        private readonly VersionMixin<SimulationVersion> _versions;

        private readonly StatusMixin<ESimulationStatus> _status;

        public Simulation(SimulationSnapshot snapshot)
        {
            Id = snapshot.Id;
            _versions = new VersionMixin<SimulationVersion>(snapshot.Versions.Select(x => new SimulationVersion(x)));
            _status = new StatusMixin<ESimulationStatus>(snapshot.Status);
        }

        public Simulation(string id, UserReference user)
        {
            Id = id;
            _status = new StatusMixin<ESimulationStatus>(ESimulationStatus.Complete, user);
            _versions = new VersionMixin<SimulationVersion>(new SimulationVersion(new Version(user)));
        }

        public string Id { get; }

        #region ITrackStatusChanges

        public ESimulationStatus Status => GetCurrentStatus();
        
        public void Set(ESimulationStatus status, UserReference user)
        {
            _status.Set(status, user);
        }

        public ESimulationStatus GetCurrentStatus()
        {
            return _status.GetCurrentStatus();
        }

        #endregion

        #region IVersionable

        public SimulationVersion GetCurrentVersion()
        {
            return _versions.GetCurrentVersion();
        }

        public int Version
        {
            get { return _versions.Version; }
        }

        public SimulationVersion Edit(UserReference user)
        {
            return _versions.Edit(user);
        }

        #endregion

        #region IStorable

        public SimulationSnapshot CreateSnapshot()
        {
            var snapshot = new SimulationSnapshot
            {
                Id = Id,
                Versions = _versions.Versions.Select(x => x.CreateSnapshot()).ToList(),
                Status = _status.Status.ToList()
            };
            return snapshot;
        }

        #endregion
    }
}
