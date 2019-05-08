using System;
using System.Windows;
using Worktime.src;

namespace Worktime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!(FindResource("Model") is Model model)) throw new Exception("Cannot find model");
            var config = ConfigHandler.Instance;
            var database = new DbHandler((string)config["url"], (string) config["db"],
                (string)config["projects"], (string) config["workitems"]);

            //model.QueryFrom = DateTime.MinValue;
            //model.QueryTo = DateTime.MaxValue;

            model.PropertyChanged += (o, args) =>
            {
                switch (args.PropertyName)
                {
                    case "QueryProject":
                        // todo update db query
                        break;
                    case "QueryFrom":
                        // todo update db query
                        break;
                    case "QueryTo":
                        // todo: update db query
                        break;
                }
            };

            database.GetProjects().ContinueWith(task =>
                Application.Current?.Dispatcher.InvokeAsync(() => task.Result.ForEach(model.Projects.Add)));
            database.GetWorkItems().ContinueWith(task =>
                Application.Current?.Dispatcher.InvokeAsync(() => task.Result.ForEach(model.WorkItems.Add)));
        }
    }
}
