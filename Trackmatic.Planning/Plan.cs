using System.Linq;
using Trackmatic.Common.Model;
using Trackmatic.Planning.Framework;
using Trackmatic.Planning.Snapshots;
using Trackmatic.Planning.Versions;

namespace Trackmatic.Planning
{
    public class Plan : IVersionable<PlanVersion>, ITrackStatusChanges<EPlanStatus>, IStorable<PlanSnapshot, PlanVersionSnapshot>
    {
        private readonly StatusMixin<EPlanStatus> _status;

        private readonly VersionMixin<PlanVersion> _version;

        public Plan(PlanSnapshot snapshot)
        {
            Id = snapshot.Id;
            _version = new VersionMixin<PlanVersion>(snapshot.Versions.Select(x => new PlanVersion(x)));
            _status = new StatusMixin<EPlanStatus>(snapshot.Status);
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

        public int Version
        {
            get { return _version.Version; }
        }

        #endregion

        #region IStorable
        
        public PlanSnapshot CreateSnapshot()
        {
            var snapshot = new PlanSnapshot
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
