using System;
using System.Collections.Generic;
using System.Text;

namespace spexco.com.modellayer.mongo
{
    public class Products : Base
    {
        public int fakestoreapiid { get; set; }
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
