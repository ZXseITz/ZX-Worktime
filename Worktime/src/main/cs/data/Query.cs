using System;

namespace Worktime.src.main.cs.data
{
    public class Query: AbstractModel
    {
        private Project _project;
        public Project Project
        {
            get => _project;
            set
            {
                _project = value;
                OnPropertyChanged();
            }
        }

        private DateTime? _from;
        public DateTime? From
        {
            get => _from;
            set
            {
                _from = value;
                OnPropertyChanged();
            }
        }

        private DateTime? _to;
        public DateTime? To
        {
            get => _to;
            set
            {
                _to = value;
                OnPropertyChanged();
            }
        }
    }
}
