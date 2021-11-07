using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spexco.com.servicehost.api.RequestResponse.Cart
{
    public class AddProductRequest
    {
        public List<AddProductItem> products { get; set; }
    }
}
