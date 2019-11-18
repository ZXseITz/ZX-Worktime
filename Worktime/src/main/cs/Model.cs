using System.Collections.ObjectModel;
using Worktime.src.main.cs.data;
using Worktime.src.main.cs.src.main.cs.data;

namespace Worktime.src.main.cs
{
    public class Model
    {
        public ObservableCollection<Project> Projects { get; }
        public ObservableCollection<Item> Items { get; }
        public Query Query { get; }
        public Result Result { get; }

        public Model()
        {
            Projects = new ObservableCollection<Project>();
            Items = new ObservableCollection<Item>();
            Query = new Query();
            Result = new Result();
        }
    }
}
