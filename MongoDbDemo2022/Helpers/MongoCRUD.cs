using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDemo2022.Helpers
{
    public class MongoCRUD
    {
        private IMongoDatabase _db;

        public MongoCRUD(string dbname)
        {
            var client = new MongoClient();
            _db = client.GetDatabase(dbname);
        }

        public void Create<T>(string collectionName, T document)
        {
            var collection = _db.GetCollection<T>(collectionName);
            collection.InsertOne(document);
        }

        public List<T> List<T>(string collectionName) // all
        {
            var collection = _db.GetCollection<T>(collectionName);
            return collection.Find(new BsonDocument()).ToList();
        }

        public T Read<T>(string collectionName, Guid id)
        {
            var collection = _db.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("Id", id);
            return collection.Find(filter).First();
        }
        public void Delete<T>(string collectionName, Guid id)
        {
            var collection = _db.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("Id", id);
            collection.DeleteOne(filter);
        }

        public void Upsert<T>(string collectionName, Guid id, T document)
        {
            BsonBinaryData binId = new BsonBinaryData(id, GuidRepresentation.Standard);
            var collection = _db.GetCollection<T>(collectionName);
            var result = collection.ReplaceOne(
                    new BsonDocument("_id", binId),
                    document,
                    new ReplaceOptions { IsUpsert = true}
                );
        }
    }
}
