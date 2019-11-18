using System;

namespace Worktime.src.main.cs.data
{
    public class Query: AbstractModel
    {
        private int _queryProject;
        public int QueryProject
        {
            get => _queryProject;
            set
            {
                _queryProject = value;
                OnPropertyChanged();
            }
        }

        private DateTime _queryFrom;
        public DateTime QueryFrom
        {
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
    }
}
