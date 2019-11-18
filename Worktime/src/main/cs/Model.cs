using System.Collections.ObjectModel;
using Worktime.src.main.cs.data;

namespace Worktime.src.main.cs
{
    public class Model
    {
        public ObservableCollection<Project> Projects { get; }
        public ObservableCollection<Item> Items { get; }
        public ObservableCollection<Item> Result { get; }

        public Query Query { get; }

        public Model()
        {
            Projects = new ObservableCollection<Project>();
            Items = new ObservableCollection<Item>();
            Result = new ObservableCollection<Item>();
            Query = new Query();
        }
    }
}
