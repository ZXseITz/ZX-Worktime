using System;

namespace Worktime.src.main.cs.data
{
    public class Item : AbstractModel
    {
        private Project _project;
        private DateTime _from;
        private DateTime _to;
        private string _description;

        public Project Project
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

        public Item(Project project, DateTime from, DateTime to, string description)
        {
            _project = project;
            _from = from;
            _to = to;
            _description = description;
        }
    }
}