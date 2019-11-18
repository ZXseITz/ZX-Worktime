using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using IX.StandardExtensions.Extensions;
using Newtonsoft.Json.Linq;
using Worktime.src.main.cs;
using Worktime.src.main.cs.data;


namespace Worktime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly string dir = "D:\\OneDrive\\Documents\\Worktime";
        public static readonly string projectFile = "projects.json";
        public static readonly string itemFile = "items.json";

        private Model _model;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            _model = FindResource("Model") as Model;
            if (_model == null) throw new Exception("Cannot find model");
            await Load();
            await Filter();
        }

        private async Task Load()
        {
            var taskProjects = Task.Run(() =>
            {
                var projects = new Dictionary<int, Project>();
                var json = File.ReadAllText(dir + "\\" + projectFile);
                var array = JArray.Parse(json);
                foreach (var item in array.Children())
                {
                    var id = (int)item["id"];
                    var name = (string)item["name"];
                    projects.Add(id, new Project(id, name));
                }
                return projects;
            });
            var taskItems = Task.Run(async () =>
            {
                var items = new List<Item>();
                var json = File.ReadAllText(dir + "\\" + itemFile);
                var array = JArray.Parse(json);
                var projects = await taskProjects;
                foreach (var item in array.Children())
                {
                    var project = projects[(int)item["project"]];
                    var from = (DateTime)item["from"];
                    var to = (DateTime)item["to"];
                    var description = (string)item["description"];
                    items.Add(new Item(project, from, to, description));
                }
                return items;
            });
            var projectMap = await taskProjects;
            _model.Projects.Clear();
            projectMap.Values.ForEach(project => _model.Projects.Add(project));
            var itemList = await taskItems;
            _model.Items.Clear();
            itemList.ForEach(item => _model.Items.Add(item));
        }

        private async Task Save()
        {
            var taskProjects = Task.Run(() =>
            {

            });
            var taskItems = Task.Run(() =>
            {

            });
            await taskProjects;
            await taskItems;
        }

        private async Task Filter()
        {
            var taskFilter = Task.Run(() =>
            {
                var query = _model.Query;
                return _model.Items.Where(item => (query.Project == null || item.Project == query.Project)
                                                  && (query.From == null || item.From >= query.From)
                                                  && (query.To == null || item.To <= query.To));
            });
            var filteredItems = await taskFilter;
            _model.Result.Clear();
            filteredItems.ForEach(item => _model.Result.Add(item));
        }
    }
}