using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Worktime.src;

namespace Worktime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Model _model;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _model = FindResource("Model") as Model;
            if (_model == null) throw new Exception("Cannot find model");
            var config = ConfigHandler.Instance;
            var database = new DbHandler((string)config["url"], (string) config["db"],
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

            database.GetProjects().ContinueWith(task =>
                Application.Current?.Dispatcher.InvokeAsync(() => task.Result.ForEach(_model.Projects.Add)));
            database.GetWorkItems().ContinueWith(task =>
                Application.Current?.Dispatcher.InvokeAsync(() => task.Result.ForEach(_model.WorkItems.Add)));
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.N && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                AddWorkItem();
            }
        }

        private void AddWorkItem()
        {
            //var work = new WorkItem("", DateTime.Now, DateTime.Now, "");
            //var window = new WorkItemWindow(work);
            var window = new WorkItemWindow();
            window.Show();
        }
    }
}
