using System.Collections.ObjectModel;

namespace Worktime.src.main.cs.data
{
    public class Result: AbstractModel
    {
        public ObservableCollection<Item> Items { get; }

        private double _time;
        public double Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

        public Result()
        {
            Items = new ObservableCollection<Item>();
        }
    }
}
