using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
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

        private async void OnFilter(object sender, RoutedEventArgs e)
        {
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
                    var id = (int) item["id"];
                    var name = (string) item["name"];
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
                    var project = projects[(int) item["project"]];
                    var date = (DateTime) item["date"];
                    var timeSpan = TimeSpan.FromHours((double) item["hours"]);
                    var description = (string) item["description"];
                    items.Add(new Item(project, description, date, timeSpan));
                }

                return items;
            });
            var projectMap = await taskProjects;
            _model.Projects.Collection.Clear();
            projectMap.Values.ForEach(project => _model.Projects.Collection.Add(project));
            var itemList = await taskItems;
            _model.Items.Clear();
            itemList.ForEach(item => _model.Items.Add(item));
        }

        private async Task Save()
        {
            var taskProjects = Task.Run(() => { });
            var taskItems = Task.Run(() => { });
            await taskProjects;
            await taskItems;
        }

        private async Task Filter()
        {
            var taskFilter = Task.Run(() =>
            {
                var query = _model.Query;
                var items = new List<Item>();
                var sum = 0.0;
                foreach (var item in _model.Items)
                {
                    if ((query.Project == null || item.Project == query.Project)
                        && (query.From == null || item.Date >= query.From)
                        && (query.To == null || item.Date <= query.To))
                    {
                        items.Add(item);
                        sum += item.TimeSpan.TotalHours;
                    }
                }

                return (items, sum);
            });
            var (filteredItems, hours) = await taskFilter;
            _model.Result.Items.Clear();
            filteredItems.ForEach(item => _model.Result.Items.Add(item));
            _model.Result.Time = hours;
        }

        private void UpdateSourcePropertyOnEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && sender is TextBox tb)
            {
                var binding = BindingOperations.GetBindingExpression(tb, TextBox.TextProperty);
                binding?.UpdateSource();
            }
        }
    }
}