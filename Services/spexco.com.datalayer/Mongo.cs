using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;

namespace spexco.com.datalayer
{
    class Mongo
    {
        public static readonly Mongo Instance = new Mongo();
        public static MongoDatabase GetMongoDatabase { get; private set; }
        Mongo()
        {



            string dbName = spexco.com.modellayer.AppSettings.GetKeyToData<string>("AppSettings:mongodbname");
            string connectionString = spexco.com.modellayer.AppSettings.GetKeyToData<string>("AppSettings:mongoconnection");

            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var client = new MongoClient(settings);
            var server = client.GetServer();
            var url = new MongoUrl(connectionString).DatabaseName;
            GetMongoDatabase = server.GetDatabase(dbName);

        }
        public MongoCollection<T> GetCollection<T>()
        {
            string name = typeof(T).Name;
            return GetMongoDatabase.GetCollection<T>(name);
        }
        public T Get<T>(string objectId)
        {
            var collection = GetCollection<T>();
            return collection.Find(Query.EQ("_id", ObjectId.Parse(objectId))).FirstOrDefault();
        }
        public T[] GetAllEntities<T>()
        {
            var collection = GetCollection<T>();
            return collection.FindAll().ToArray();
        }
        public List<T> GetAllEntitiesWithQuery<T>(string queryKey, dynamic queryValue)
        {
            var collection = GetCollection<T>();
            BsonValue b = BsonValue.Create(queryValue);
            return collection.Find(Query.EQ(queryKey, b)).ToList();
        }
        public long GetAllEntitiesWithQueryCount<T>(string queryKey, T queryValue)
        {
            var collection = GetCollection<T>();
            BsonValue b = BsonValue.Create(queryValue);
            return collection.Find(Query.EQ(queryKey, b)).Count();
        }
        public T Insert<T>(T entity)
        {
            var collection = GetCollection<T>();
            collection.Insert(entity);
            return entity;
        }
        public List<T> InsertMany<T>(List<T> entity)
        {
            var collection = GetCollection<T>();
            collection.InsertBatch<T>(entity);
            return entity;
        }
        public bool UpdateEntity<T>(T entity)
        {
            var collection = GetCollection<T>();
            var result = collection.Save(entity);
            return result.DocumentsAffected > 0;
        }

        public bool DeleteEntity<T>(string objectId)
        {
            var collection = GetCollection<T>();
            var result = collection.Remove(Query.EQ("_id", ObjectId.Parse(objectId)));
            return result.DocumentsAffected > 0;
        }
    }
}
