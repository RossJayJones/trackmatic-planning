using System.Collections.Generic;
using System.Linq;
using Trackmatic.Common.Model;
using Trackmatic.Planning.Framework;
using Trackmatic.Planning.Snapshots;

namespace Trackmatic.Planning.Versions
{
    public class PlanVersion : IVersion<PlanVersion>, IStorableVersion<PlanVersionSnapshot>
    {
        private readonly ReadonlyMixin _readonly;

        private readonly VersionData _version;

        private readonly List<Simulation> _simulations;

        private readonly List<Action> _actions;

        private readonly List<Resource> _resources;

        private string _name;

        private Depot _depot;

        private PlanVersion(PlanVersionSnapshot snapshot, UserReference user) : this(snapshot)
        {
            _version = _version.Increment(user);
            _readonly = new ReadonlyMixin(false);
        }

        public PlanVersion(PlanVersionSnapshot snapshot)
        {
            _version = new VersionData(snapshot.Version);
            _simulations = snapshot.Simulations.Select(x => new Simulation(x)).ToList();
            _name = snapshot.Name;
            _actions = snapshot.Actions;
            _resources = snapshot.Resources;
            _depot = snapshot.Depot;
            _readonly = new ReadonlyMixin(true);
        }

        public PlanVersion(VersionData version)
        {
            _version = version;
            _simulations = new List<Simulation>();
            _actions = new List<Action>();
            _resources = new List<Resource>();
        }

        public VersionData Version => _version;

        public string Name
        {
            get { return _name; }
            set
            {
                _readonly.Guard();
                _name = value;
            }
        }

        public IEnumerable<Action> Actions => _actions;

        public IEnumerable<Resource> Resources => _resources;

        public IEnumerable<Simulation> Simulations => _simulations;

        public Depot Depot
        {
            get { return _depot; }
            set
            {
                _readonly.Guard();
                _depot = value;
            }
        }

        public PlanVersion Edit(UserReference user)
        {
            var snapshot = CreateSnapshot();
            var clone = snapshot.Clone();
            return new PlanVersion(clone, user);
        }
        
        public VersionData Current => _version;

        public PlanVersionSnapshot CreateSnapshot()
        {
            var memento = new PlanVersionSnapshot
            {
                Actions = Actions.ToList(),
                Depot = Depot,
                Name = Name,
                Resources = Resources.ToList(),
                Version = new VersionDataSnapshot(Version),
                Simulations = Simulations.Select(x => x.CreateSnapshot()).ToList()
            };
            return memento;
        }

        public void Add(Simulation simulation)
        {
            _simulations.Add(simulation);
        }

        public void Add(Action action)
        {
            _readonly.Guard();
            _actions.Add(action);
        }

        public void Add(Resource resource)
        {
            _readonly.Guard();
            _resources.Add(resource);
        }

        public Simulation GetSimulationById(string id)
        {
            return _simulations.SingleOrDefault(x => x.Id == id);
        }
    }
}
