using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spexco.com.servicehost.api.RequestResponse.Cart
{
    public class CartProductDTO
    {
        public string productId { get; set; }
        public int quantity { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string images { get; set; }
        public string description { get; set; }
    }
}
