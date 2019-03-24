using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Worktime.src
{
    public class DbHandler
    {
        private IMongoCollection<BsonDocument> _projects;
        private IMongoCollection<BsonDocument> _workitems;

        public DbHandler(string url, string dbName, string projectCollectionName, string workitemCollectionName)
        {
            var client = new MongoClient(new MongoUrl(url));
            var database = client.GetDatabase(dbName);
            _projects = database.GetCollection<BsonDocument>(projectCollectionName);
            _workitems = database.GetCollection<BsonDocument>(workitemCollectionName);
        }

        public async Task AddProject(string name)
        {
            var document = new BsonDocument()
            {
                {"name", name}
            };
            await _projects.InsertOneAsync(document);
        }

        public async Task<List<string>> GetProjects()
        {
            var projects = new List<string>();
            using (var cursor = await _projects.FindAsync(new BsonDocument()))
            {
                while (await cursor.MoveNextAsync())
                {
                    projects.AddRange(cursor.Current.Select(document => (string) document["name"]));
                }
            }

            return projects;
        }
    }
}
