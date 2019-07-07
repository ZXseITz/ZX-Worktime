

using MongoDB.Bson;

namespace Worktime.src.data
{
    public class Project : AbstractModel
    {
        public ObjectId Id { get; }

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

        public Project(ObjectId id, string name)
        {
            Id = id;
            _name = name;
        }
    }
}