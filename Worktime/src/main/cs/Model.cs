using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Worktime.src.main.cs.data;

namespace Worktime.src.main.cs
{
    public class Model
    {
        public static readonly string dir = "D:\\OneDrive\\Documents\\Worktime";
        public static readonly string projectFile = "projects.json";
        public static readonly string itemFile = "items.json";

        public ObservableCollection<Project> Projects { get; }
        public ObservableCollection<Item> Items { get; }

        public Query Query { get; }

        public Model()
        {
            Projects = new ObservableCollection<Project>();
            Items = new ObservableCollection<Item>();
        }

        public async void load()
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
                    var from = (DateTime) item["from"];
                    var to = (DateTime) item["to"];
                    var description = (string) item["description"];
                    items.Add(new Item(project, from, to, description));
                }
                return items;
            });

            foreach (var project in await taskProjects)
            {
                Projects.Add(project.Value);
            }
            foreach (var item in await taskItems)
            {
                Items.Add(item);
            }
        }

        public async void save()
        {
            Task.Run(() =>
            {

            });
        }
    }
}
