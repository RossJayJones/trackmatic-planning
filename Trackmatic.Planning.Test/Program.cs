using System;
using System.IO;
using System.Linq;
using Raven.Client.Document;
using Raven.Imports.Newtonsoft.Json;
using Trackmatic.Common.Model;
using Trackmatic.Planning.Storage;
using Trackmatic.Planning.Test.Model;

namespace Trackmatic.Planning.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var plan = Get("6");

                Console.WriteLine(JsonConvert.SerializeObject(plan, Formatting.None));

                Console.WriteLine("Enter a name: ");

                var name = Console.ReadLine();

                Post("6", new PlanModel {Name = name});
            }
        }

        private static dynamic Get(string id)
        {
            var store = new DocumentStore
            {
                Url = "http://localhost:8092"
            };

            store.Initialize();

            var storage = new RavenPlanStorage(store);

            var plan = storage.Get("6");

            return CreatePlanDto(plan);
        }

        private static void Post(string id, PlanModel model)
        {
            var store = new DocumentStore
            {
                Url = "http://localhost:8092"
            };

            store.Initialize();

            var storage = new RavenPlanStorage(store);

            var user = new UserReference { Id = "1", Name = "TEst" };

            var plan = storage.Get("6");

            var current = plan.Edit(user);

            current.Name = model.Name;

            storage.Store(plan);
        }

        private static dynamic CreatePlanDto(Plan plan)
        {
            var current = plan.GetCurrentVersion();
            var dto = new
            {
                plan.Id,
                plan.Status,
                current.Name,
                plan.Version,
                Actions = current.Actions.Select(x => new
                {
                    x.Id
                }),
                Resources = current.Resources.Select(x => new
                {
                    x.Id,
                    x.Qty
                }),
                current.Depot,
                Simulations = current.Simulations.Select(CreateSimulationDto)
            };
            return dto;
        }

        private static dynamic CreateSimulationDto(Simulation simulation)
        {
            var current = simulation.GetCurrentVersion();
            var dto = new
            {
                simulation.Id,
                simulation.Status,
                simulation.Version,
                Runs = current.Runs.Select(x => new
                {
                    x.Id,
                    x.Resource,
                    x.Status,
                    x.Time,
                    x.Actions
                })
            };
            return dto;
        }
    }
}
