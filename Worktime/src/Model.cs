using System;
using System.Collections.ObjectModel;

namespace Worktime
{
    public class Model
    {
        public ObservableCollection<string> Projects { get; }
        public ObservableCollection<WorkItem> WorkItems { get; }
        public string QueryProject { get; set; }
        public DateTime QueryFrom { get; set; }
        public DateTime QueryTo { get; set; }
        public double Total { get; set; }

        public Model()
        {
            Projects = new ObservableCollection<string>();
            WorkItems = new ObservableCollection<WorkItem>();
        }
    }
}
