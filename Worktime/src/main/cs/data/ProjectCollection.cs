using System.Collections.ObjectModel;
using Worktime.src.main.cs.data;

namespace Worktime.src.main.cs.src.main.cs.data
{
    public class ProjectCollection: AbstractModel
    {
        public ObservableCollection<Project> Collection { get; }

        private Project _selection;
        public Project Selection
        {
            get => _selection;
            set
            {
                _selection = value;
                OnPropertyChanged();
            }
        }

        public ProjectCollection()
        {
            Collection = new ObservableCollection<Project>();
        }
    }
}
