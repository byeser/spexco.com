using spexco.com.modellayer.mongo;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace spexco.com.datalayer.Repositories
{
    public static class ProductRepository
    {
        public static List<Products> GetAllPaging(string category="", int pageSize = 10, int pageNumber = 1, string sortDirection = "asc")
        {
            var collection = Mongo.Instance.GetCollection<Products>();           
            if (!string.IsNullOrEmpty(category))
            {
                var queries = new IMongoQuery[] { }.ToList();
                queries.Add(Query.EQ("category", category));
                return collection.Find(Query.And(queries)).SetCollation(new Collation("en", strength: CollationStrength.Primary)).SetSortOrder(sortDirection == "asc" ? SortBy.Ascending("title") : SortBy.Descending("title")).SetSkip((pageNumber - 1) * pageSize).SetLimit(pageSize).ToList();
            }
            return collection.FindAll().SetCollation(new Collation("en", strength: CollationStrength.Primary)).SetSortOrder(sortDirection == "asc" ? SortBy.Ascending("title") : SortBy.Descending("title")).SetSkip((pageNumber - 1) * pageSize).SetLimit(pageSize).ToList();

        }
        public static long GetAllPagingCount(string category="")
        {
            var collection = Mongo.Instance.GetCollection<Products>();
            if (!string.IsNullOrEmpty(category))
            {
                var queries = new IMongoQuery[] { }.ToList();
                queries.Add(Query.EQ("category", category));
                return collection.Find(Query.And(queries)).Count();
            }
            return collection.FindAll().Count();


        }
        public static Products GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return default(Products);

            var collection = Mongo.Instance.GetCollection<Products>();
            var queries = new IMongoQuery[] { }.ToList();
            queries.Add(Query.EQ("_id", ObjectId.Parse(id)));
            return collection.Find(Query.And(queries)).FirstOrDefault();
        }
        public static List<string> GetCategoriesList()
        {
            var collection = Mongo.Instance.GetCollection<Products>();
            return collection.FindAll().GroupBy(x=>x.category).Select(x=>x.Key).ToList();
        }
    }
}
