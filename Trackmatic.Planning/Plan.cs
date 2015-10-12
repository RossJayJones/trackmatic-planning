using System.Linq;
using Trackmatic.Common.Model;
using Trackmatic.Planning.Framework;
using Trackmatic.Planning.Snapshots;
using Trackmatic.Planning.Versions;

namespace Trackmatic.Planning
{
    public class Plan : IVersionable<PlanVersion>, ITrackStatusChanges<EPlanStatus>, IStorable<PlanVersionableSnapshot, PlanVersionSnapshot>
    {
        private readonly StatusMixin<EPlanStatus> _status;

        private readonly VersionMixin<PlanVersion> _version;

        public Plan(PlanVersionableSnapshot versionableSnapshot)
        {
            Id = versionableSnapshot.Id;
            _version = new VersionMixin<PlanVersion>(versionableSnapshot.Versions.Select(x => new PlanVersion(x)));
            _status = new StatusMixin<EPlanStatus>(versionableSnapshot.Status);
        }
        
        public Plan(string id, UserReference user)
        {
            Id = id;
            _status = new StatusMixin<EPlanStatus>(EPlanStatus.Active, user);
            _version = new VersionMixin<PlanVersion>(new PlanVersion(new Version(user)));
        }

        #region Public Properties

        public string Id { get; }

        #endregion

        #region ITrackStatusChanges

        public EPlanStatus Status => GetCurrentStatus();
        
        public EPlanStatus GetCurrentStatus()
        {
            return _status.GetCurrentStatus();
        }
        
        public void Set(EPlanStatus status, UserReference user)
        {
            _status.Set(status, user);
        }

        #endregion

        #region IVersionable
        
        public PlanVersion Edit(UserReference user)
        {
            return _version.Edit(user);
        }

        public PlanVersion GetCurrentVersion()
        {
            return _version.GetCurrentVersion();
        }

        public int Version => _version.Version;

        #endregion

        #region IStorable
        
        public PlanVersionableSnapshot CreateSnapshot()
        {
            var snapshot = new PlanVersionableSnapshot
            {
                Id = Id,
                Status = _status.Status.ToList(),
                Versions = _version.Versions.Select(x => x.CreateSnapshot()).ToList()
            };
            return snapshot;
        }

        #endregion
    }
}
