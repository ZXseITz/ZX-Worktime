using System;
using System.Collections.ObjectModel;

namespace Worktime
{
    public class Model : AbstractModel
    {

        public ObservableCollection<string> Projects { get; }
        public ObservableCollection<WorkItem> WorkItems { get; }

        private string _queryProject;
        public string QueryProject
        {
            get => _queryProject;
            set
            {
                _queryProject = value;
                OnPropertyChanged();
            }
        }

        private DateTime _queryFrom;
        public DateTime QueryFrom {
            get => _queryFrom;
            set
            {
                _queryFrom = value;
                OnPropertyChanged();
            }
        }

        private DateTime _queryTo;
        public DateTime QueryTo
        {
            get => _queryTo;
            set
            {
                _queryTo = value;
                OnPropertyChanged();
            }
        }

        private double _total;
        public double Total
        {
            get => _total;
            set
            {
                _total = value;
                OnPropertyChanged();
            }
        }

        public Model()
        {
            Projects = new ObservableCollection<string>();
            WorkItems = new ObservableCollection<WorkItem>();
        }
    }
}
