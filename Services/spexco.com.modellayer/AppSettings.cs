using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace spexco.com.modellayer
{
    public static class AppSettings
    {
        /// <summary>
        /// Appsettings deki dataları getirir 
        /// </summary>
        /// <param name="key">Getirilerek datanın key i</param>
        /// <returns></returns>
        public static T GetKeyToData<T>(string key)
        {
            var builder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return (T)Convert.ChangeType(builder.Build()[key], typeof(T));
        }
    }
}
