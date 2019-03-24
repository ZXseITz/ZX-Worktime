using System;

namespace Worktime
{
     public struct WorkItem
    {
        public string Project { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public double Total { get; set; }
        public string Description { get; set; }

        public WorkItem(string project, DateTime from, DateTime to, string description)
        {
            Project = project;
            From = from;
            To = to;
            Total = 0;
            Description = description;
        }
    }
}
