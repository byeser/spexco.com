using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
 

namespace spexco.com.ui.utils.session
{
    public static class helper<T> where T : class
    {
        /// <summary>
        /// Session ekler
        /// </summary>
        /// <param name="cntx"></param>
        /// <param name="req"> data</param>
        /// <param name="key">session key</param>
        /// <returns></returns>
        public static T add(Microsoft.AspNetCore.Http.HttpContext cntx, T req, string key)
        {

            if (req == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, req);

            cntx.Session.Set(key, ms.ToArray());
            return req;
        }
        /// <summary>
        /// Session getirir.
        /// </summary>
        /// <param name="cntx"></param>
        /// <param name="key">session key</param>
        /// <returns></returns>
        public static T get(Microsoft.AspNetCore.Http.HttpContext cntx, string key)
        {
            try
            {
                byte[] readData;
                var data = cntx.Session.TryGetValue(key, out readData);
                if (data)
                {
                    MemoryStream memStream = new MemoryStream();
                    BinaryFormatter binForm = new BinaryFormatter();
                    memStream.Write(readData, 0, readData.Length);
                    memStream.Seek(0, SeekOrigin.Begin);
                    return binForm.Deserialize(memStream) as T;
                }

            }
            catch (Exception)
            {
            }
            return null;
        }
        /// <summary>
        /// Session kaldırır
        /// </summary>
        /// <param name="cntx"></param>
        /// <param name="key"></param>
        public static void remove(Microsoft.AspNetCore.Http.HttpContext cntx, string key)
        {
            cntx.Session.Remove(key);
        }
        /// <summary>
        /// Session kontrol eder var mı ? yok mu ?
        /// </summary>
        /// <param name="cntx"></param>
        /// <param name="key">session key</param>
        /// <returns></returns>
        public static bool is_exist(Microsoft.AspNetCore.Http.HttpContext cntx, string key)
        {
            return cntx.Session.TryGetValue(key, out byte[] result);
        }
    }
}
