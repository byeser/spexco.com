using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace spexco.com.restapi.utils.connection
{
    /// <summary>
    /// veritabanı bağlantısı
    /// </summary>
    public static class helper
    {
        /// <summary>
        /// veritabanı bağlantısı geri dönderir.
        /// </summary>
        /// <returns></returns>
        public static IDbConnection get_connection()
        {
            IDbConnection conn = default;

            conn = new SqlConnection(utils.ux.helper.get_appsettings<string>("AppSettings:connection"));
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            return conn;
        }
    }
}
