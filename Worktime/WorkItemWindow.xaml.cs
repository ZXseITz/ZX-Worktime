using System.Windows;

namespace Worktime
{
    /// <summary>
    /// Interaction logic for WorkItemWindow.xaml
    /// </summary>
    public partial class WorkItemWindow : Window
    {
        private Model _model;
        private WorkItemModel _itemModel;
        //private WorkItem _item;

        public WorkItemWindow(/* WorkItem item */)
        {
            InitializeComponent();
            //_item = item;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _model = FindResource("Model") as Model;
            _itemModel = FindResource("Item") as WorkItemModel;
            //_itemModel.Project = _item.Project;
            //_itemModel.From = _item.From;
            //_itemModel.To = _item.To;
            //_itemModel.Description = _item.Description;

            //_itemModel.PropertyChanged += (o, args) =>
            //{
            //    switch (args.PropertyName)
            //    {
            //        case "Project":
            //            _item.Project = _itemModel.Project;
            //            break;
            //        case "From":
            //            _item.From = _itemModel.From;
            //            break;
            //        case "To":
            //            _item.To = _itemModel.To;
            //            break;
            //        case "Description":
            //            _item.Description = _itemModel.Description;
            //            break;
            //    }
            //};
        }

        private void OnCreate(object sender, RoutedEventArgs e)
        {
            var item = new WorkItem(_itemModel.Project, _itemModel.From, _itemModel.To, _itemModel.Description);
            _model.WorkItems.Add(item);
            Close();
        }
    }
}
