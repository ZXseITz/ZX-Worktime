using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Worktime.src.data;

namespace Worktime.src
{
    public class DbHandler
    {
        private IMongoCollection<BsonDocument> _projects;
        private IMongoCollection<BsonDocument> _workitems;

        public DbHandler(string host, int port, string dbName,
            string projectCollectionName, string workitemCollectionName)
        {
            var client = new MongoClient(new MongoClientSettings()
            {
                Server = new MongoServerAddress(host, port)
            });
            var database = client.GetDatabase(dbName);
            _projects = database.GetCollection<BsonDocument>(projectCollectionName);
            _workitems = database.GetCollection<BsonDocument>(workitemCollectionName);
        }

        // ************
        //   Projects  
        // ************

        public async void CreateProject(Project project)
        {
            var document = new BsonDocument()
            {
                {"_id", project.Id},
                {"name", project.Name}
            };
            await _projects.InsertOneAsync(document);
        }

        public async Task<List<Project>> GetProjects()
        {
            var projects = new List<Project>();
            using (var cursor = await _projects.FindAsync(new BsonDocument()))
            {
                while (await cursor.MoveNextAsync())
                {
                    projects.AddRange(cursor.Current.Select(document =>
                        new Project(document["_id"].AsObjectId, document["name"].AsString)));
                }
            }
            return projects;
        }

        public async void UpdateProject(Project project)
        {
            await _projects.UpdateOneAsync(new BsonDocument(){
                    {"_id", project.Id}
                }, 
                new BsonDocumentUpdateDefinition<BsonDocument>(new BsonDocument() {
                    {"name", project.Name}
                }));
        }

        public async void DeleteProject(Project project)
        {
            await _projects.DeleteOneAsync(new BsonDocument(){
                    {"_id", project.Id}
                });
        }

        // *************
        //   WorkItems  
        // *************


    }
}
