using System;
using System.Windows;
using System.Windows.Documents;
using Worktime.src;

namespace Worktime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DbHandler db;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var model = FindResource("Model") as Model;
            var config = ConfigHandler.Instance;
            var db = new DbHandler((string)config["url"], (string) config["db"],
                (string)config["projects"], (string) config["workitems"]);

            //model.QueryFrom = DateTime.MinValue;
            //model.QueryTo = DateTime.MaxValue;

            var projectNames = db.GetProjects().ContinueWith(task => model.Projects.AddRange(task.Result));

            //model.WorkItems.Add(new WorkItem("SMESEC", DateTime.Now, DateTime.Now, "test"));

        }
    }
}
