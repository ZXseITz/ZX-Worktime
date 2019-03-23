using System;
using System.Collections.Generic;

namespace Worktime
{
    public class Model
    {
        public List<string> Projects { get; }
        public List<WorkItem> WorkItems { get; }
        public string QueryProject { get; set; }
        public DateTime QueryFrom { get; set; }
        public DateTime QueryTo { get; set; }
        public double Total { get; set; }

        public Model()
        {
            Projects = new List<string>();
            WorkItems = new List<WorkItem>();
        }
    }
}
