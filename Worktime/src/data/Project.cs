namespace Worktime.src.data
{
    public class Project : AbstractModel
    {
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

        public Project(string name)
        {
            _name = name;
        }
    }
}