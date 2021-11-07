using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spexco.com.ui.utils.ux
{
    public static class helper
    {
        /// <summary>
        /// Login yapan kullanıcı için session key
        /// </summary>
        public const string session_user = "user";
        public static T get_appsettings<T>(string key)
        {
            var builder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return (T)Convert.ChangeType(builder.Build()[key], typeof(T));
        }

    }
}
