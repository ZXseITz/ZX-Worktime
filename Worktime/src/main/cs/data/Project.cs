namespace Worktime.src.main.cs.data
{
    public class Project : AbstractModel
    {
        public int Id { get; }
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public Project(int id, string name)
        {
            Id = id;
            _name = name;
        }
    }
}