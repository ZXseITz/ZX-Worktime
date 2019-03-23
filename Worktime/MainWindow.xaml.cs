using System;
using System.Windows;

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
            var model = FindResource("Model") as Model;

            model.QueryFrom = DateTime.MinValue;
            model.QueryTo = DateTime.MaxValue;

            model.Projects.Add("SMESEC");
            model.Projects.Add("SolarManager");

            model.WorkItems.Add(new WorkItem("SMESEC", DateTime.Now, DateTime.Now, "test"));

        }
    }
}
