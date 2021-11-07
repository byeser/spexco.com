using spexco.com.modellayer.mongo;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spexco.com.datalayer.Repositories
{
    public class UserRepository
    {
        public static Users Login(string email, string password)
        {
            try
            {
                var collection = Mongo.Instance.GetCollection<Users>();
                List<IMongoQuery> q = new List<IMongoQuery>();
                q.Add(Query.EQ("username", email));
                q.Add(Query.EQ("password", password)); 
                var usr = collection.Find(Query.And(q)).FirstOrDefault();
                return usr;
            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}
