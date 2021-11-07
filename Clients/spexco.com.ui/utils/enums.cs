using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace spexco.com.ui.utils
{
    public class enums
    {   /// <summary>
        /// bildirim
        /// </summary>
        public enum notify : byte
        {
            none = 0,
            error = 1,
            success = 2,
            warning = 3,
        }
        /// <summary>
        /// bildirim durumları
        /// </summary>
        public enum notify_status : byte
        {
            none = 0,
            pending = 1,
            success = 2,
            error = 3,
        }
        public enum http_protocol : byte
        {
            get = 0,
            post = 1,
            put = 2,
            delete = 3
        }
        public enum gender : byte
        {
            none = 0,
            male = 1,
            female = 2,
        }
        public enum housing_situation:byte
        {
            sold=1,
            rented=2,
            wait=3
        }
        public enum typewarming:byte
        {
            /// <summary>
            /// doğalgaz
            /// </summary>
            naturalgas=1,
            /// <summary>
            /// kömür
            /// </summary>
            coal=2,
            /// <summary>
            /// merkezi sistem
            /// </summary>
            centralsystem=3
        }
        public enum realestate_type:byte
        {
            /// <summary>
            /// satlık
            /// </summary>
            sale=1,
            /// <summary>
            /// kiralık
            /// </summary>
            rent=2
        }
    }
}
