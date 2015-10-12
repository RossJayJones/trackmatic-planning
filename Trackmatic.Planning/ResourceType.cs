using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackmatic.Planning
{
    public class ResourceType
    {
        public string Id { get; set; }

        public int Quantity { get; set; }

        public List<Resource> Resources { get; set; }
    }
}
