using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spexco.com.servicehost.api.RequestResponse.Cart
{
    public class GetCartProducts
    {
        public GetCartProducts()
        {
            products = new List<CartProductDTO>();
        }
        public double total { get; set; }
        public List<CartProductDTO> products { get; set; }
    }
}
