using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Worktime
{
    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
