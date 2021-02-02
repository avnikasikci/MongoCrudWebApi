using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace MangoCrudWebApi.Core
{
    public class CategoryService
    {
        ////private readonly IMongoDbSettings settings;  // Simdilik kalsın
        private readonly IMongoCollection<Category> _Category;
        public CategoryService(IMongoDbSettings settings)
        {
            //this.settings = settings;

            //MongoClient client = new MongoClient("http://localhost:27017/");
            MongoClient client = new MongoClient(settings.ConnectionString);
            //var db = client.GetDatabase("DbDemoCategory");
            var db = client.GetDatabase(settings.Database);
            //_Category = db.GetCollection<Category>("Category");
            _Category = db.GetCollection<Category>(settings.Collection);
        }
        public List<Category> GetAll() => _Category.Find(t => true).ToList();
        public Category SelectById(string ObjectId) => _Category.Find(t => t.ObjectId == ObjectId).FirstOrDefault();

    }
}