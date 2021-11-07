using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spexco.com.ui.utils
{
    public static class HttpContext
    {
        private static IHttpContextAccessor _contextAccessor;

        /// <summary>
        /// .net core da HttpContext.Current a direk ulaşılamıyor ,IHttpContextAccessor interface aracılığıyla ulaşıldıgı için ;kullanırken bunu cağırmanız gerekiyor
        /// </summary>
        public static Microsoft.AspNetCore.Http.HttpContext Current => _contextAccessor.HttpContext;

        internal static void Configure(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
    }
}
