using spexco.com.ui.utils.partial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace spexco.com.ui.Models
{
    public class generate_response<T>
    {
        public notify notify { get; set; }
        public T data { get; set; }
    }
}
