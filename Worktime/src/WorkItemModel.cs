using System;

namespace Worktime
{
    public class WorkItemModel : AbstractModel
    {
        private string _project;
        private DateTime _from;
        private DateTime _to;
        private string _description;

        public string Project
        {
            get => _project;
            set
            {
                _project = value;
                OnPropertyChanged();
            }
        }

        public DateTime From
        {
            get => _from;
            set
            {
                _from = value;
                OnPropertyChanged();
            }
        }

        public DateTime To
        {
            get => _to;
            set
            {
                _to = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public WorkItemModel()
        {
            From = DateTime.Now;
            To = DateTime.Now;
        }

        public WorkItemModel(WorkItem item)
        {
            Project = item.Project;
            From = item.From;
            To = item.To;
            Description = item.Description;
        }
    }
}