using System.Collections.Generic;

namespace Trackmatic.Planning
{
    public class Run
    {
        public Run()
        {
            Actions = new List<string>();
        }

        public string Id { get; set; }

        public List<string> Actions { get; set; }

        public string Resource { get; set; }

        public Time Time { get; set; }
        
        public ERunStatus Status { get; set; }
    }
}
