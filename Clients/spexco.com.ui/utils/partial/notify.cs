 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spexco.com.ui.utils.partial
{
    public class notify
    {
        public notify()
        {
            typ = enums.notify.error;
            title = string.Empty;
            description = string.Empty;
        }

        public enums.notify typ { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}
