using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MongoDB.Bson;
using Worktime.src;
using Worktime.src.data;

namespace Worktime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Model _model;
        private DbHandler _database;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _model = FindResource("Model") as Model;
            if (_model == null) throw new Exception("Cannot find model");
            _model.Projects.Add(new Project(ObjectId.Empty, "All Projects"));
            var config = ConfigHandler.Instance;
            _database = new DbHandler((string)config["host"], (int)config["port"], (string) config["db"],
                (string)config["projects"], (string) config["workitems"]);

            //model.QueryFrom = DateTime.MinValue;
            //model.QueryTo = DateTime.MaxValue;

            //_model.PropertyChanged += (o, args) =>
            //{
            //    switch (args.PropertyName)
            //    {
            //        case "QueryProject":
            //            // todo update db query
            //            break;
            //        case "QueryFrom":
            //            // todo update db query
            //            break;
            //        case "QueryTo":
            //            // todo: update db query
            //            break;
            //    }
            //};

            _database.GetProjects().ContinueWith(task => Application.Current?.Dispatcher.InvokeAsync(() =>
                task.Result.ForEach(_model.Projects.Add)));
            //_database.GetWorkItems().ContinueWith(task => Application.Current?.Dispatcher.InvokeAsync(() =>
            //    task.Result.ForEach(_model.WorkItems.Add)));
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            //todo: remove test shortcut
            if (e.Key == Key.N && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                CreateProject("Test");
            }
        }

        private void CreateProject(string name)
        {
            var project = new Project(ObjectId.GenerateNewId(), name);
            _database.CreateProject(project);
            _model.Projects.Add(project);
        }

        private void UpdateProject(Project project)
        {
            _database.UpdateProject(project);
        }

        private void DeleteProject(Project project)
        {
            _database.DeleteProject(project);
        }
    }
}
