using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace spexco.com.modellayer.mongo
{
    public class Cart
    {
        /// <summary>
        /// set user id
        /// </summary>
        public ObjectId _id { get; set; }
        public List<CartProduct> products { get; set; } 
        public bool isDeleted { get; set; }

        public Cart(ObjectId id)
        {
            _id = id;
            products = new List<CartProduct>(); 
        }
    }
    public class CartProduct
    {
        public ObjectId _id { get; set; }
        public int quantity { get; set; }
    }
}
