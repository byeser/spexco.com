using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spexco.com.servicehost.api.RequestResponse.Product
{
    public class GetProducts
    {
        public GetProducts()
        {
            count = 0;
            products = new List<GetProduct>();
            
        }
        public List<GetProduct> products { get; set; }
        public long count { get; set; }
    }
    public class GetProduct
    {
        public string id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        public rating rating { get; set; }
    }
    public class rating
    {
        public double rate { get; set; }
        public int count { get; set; }

    }
}
