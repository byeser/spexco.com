using spexco.com.modellayer.mongo;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spexco.com.datalayer.Repositories
{
    public static class CartRepository
    {
        public static Cart GetUserCart(string userId)
        {
            if (String.IsNullOrEmpty(userId)) 
                return null; 

            var cart = GetById(userId);
            if (cart == null) return new Cart(ObjectId.Parse(userId)) { products = new List<CartProduct>() };
            if (cart.products == null) cart.products = new List<CartProduct>();
            return cart;
        }
        public static Cart GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return default(Cart);

            var collection = Mongo.Instance.GetCollection<Cart>();
            var queries = new IMongoQuery[] { }.ToList();
            queries.Add(Query.EQ("_id", ObjectId.Parse(id)));
            return collection.Find(Query.And(queries)).FirstOrDefault();
        }
        public static Cart Insert<Cart>(Cart entity)
        {
            var collection = Mongo.Instance.GetCollection<Cart>();
            collection.Insert(entity);
            return entity;
        }
        public static bool Update(Cart item)
        {
            return Mongo.Instance.UpdateEntity<Cart>(item);
        }
    }
}
