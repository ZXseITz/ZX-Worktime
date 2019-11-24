using System;

namespace Worktime.src.main.cs.data
{
    public class Item:  AbstractModel
    {
        private Project _project;
        private string _description;
        private DateTime _date;
        private TimeSpan _timeSpan;

        public Project Project
        {
            get => _project;
            set
            {
                _project = value;
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

        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value.Date;
                OnPropertyChanged();
            }
        }

        public TimeSpan TimeSpan
        {
            get => _timeSpan;
            set
            {
                _timeSpan = value;
                OnPropertyChanged();
            }
        }

        public Item(Project project, string description, DateTime date, TimeSpan timeSpan)
        {
            _project = project;
            _description = description;
            _date = date;
            _timeSpan = timeSpan;
        }
    }
}
