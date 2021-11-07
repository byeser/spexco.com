using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spexco.com.ui.Models.Product
{

    public class ProductResponse
    {
        public ProductResponse()
        {
            count = 0;
            products = new List<Product>();

        }
        public List<Product> products { get; set; }
        public long count { get; set; }
    }
    public class Product
    {
        public string id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        public Rating rating { get; set; }
    }
    public class Rating
    {
        public double rate { get; set; }
        public int count { get; set; }

    }
}
