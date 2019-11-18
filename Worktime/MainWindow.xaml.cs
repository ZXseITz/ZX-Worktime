using System;
using System.Collections.Generic;
using System.Windows;
using Worktime.src.main.cs;
using Worktime.src.main.cs.data;

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
            _model.load();
        }
    }
}