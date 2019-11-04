using System;
using System.Collections.Generic;
using System.Windows;
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
        private FileHandler<List<Project>> _projectsHandler;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            _projectsHandler = new FileHandler<List<Project>>("D:\\OneDrive\\Documents\\Worktime\\projects.json");
            _model = FindResource("Model") as Model;
            if (_model == null) throw new Exception("Cannot find model");
            _model.Projects.Add(new Project("All Projects"));

            var projectTask = _projectsHandler.Load();

            var projects = await projectTask;
            projects.ForEach(_model.Projects.Add);
        }
    }
}