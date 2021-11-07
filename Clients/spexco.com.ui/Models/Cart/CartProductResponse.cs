using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spexco.com.ui.Models.Cart
{
    public class CartProductResponse
    {
        public double total { get; set; }
        public List<ProductDTO> products { get; set; }
    }
}
