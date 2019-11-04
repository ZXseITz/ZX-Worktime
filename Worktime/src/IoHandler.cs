using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Worktime.src
{
    public class FileHandler<T>
    {
        public readonly string Path;

        public FileHandler(string path)
        {
            Path = path;
        }

        public Task<T> Load()
        {
            return Task.Run(() =>
            {
                var json = File.ReadAllText(Path);
                return JsonConvert.DeserializeObject<T>(json);
            });
        }

        public Task Write(T obj)
        {
            return Task.Run(() =>
            {
                var json = JsonConvert.SerializeObject(obj);
                File.WriteAllText(Path + ".tmp", json);
                File.Move(Path + ".tmp", Path);
            });
        }
    }
}
