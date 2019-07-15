using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Worktime.src
{
    public class ConfigHandler
    {
        private static ConfigHandler _instance;
        private const string Config = "res/config.json";

        public static ConfigHandler Instance => _instance ?? (_instance = new ConfigHandler());

        private Dictionary<string, object> _configs;

        private ConfigHandler()
        {
            _configs = new Dictionary<string, object>();
            if (!File.Exists(Config)) return;
            var json = File.ReadAllText(Config);
            var conf = JObject.Parse(json);

            _configs.Add("host", conf.Value<string>("host"));
            _configs.Add("port", conf.Value<int>("port"));
            _configs.Add("db", conf.Value<string>("database_name"));
            _configs.Add("projects", conf.Value<string>("project_collection_name"));
            _configs.Add("workitems", conf.Value<string>("workitem_collection_name"));
        }

        public object this[string key] => _configs[key];
    }
}
