using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spexco.com.ui.utils.datetime
{
    /// <summary>
    /// Tarih işlemleri
    /// </summary>
    public static class helper
    {
        /// <summary>
        /// Türkiye formatına göre tarih
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime get_date_from_object(params object[] obj)
        {
            var date = DateTime.Now;
            foreach (var o in obj)
            {
                if (o != null)
                {
                    var str = o.ToString().Replace("_", ".").Replace("-", ".").Replace("/", ".");
                    var dt = DateTime.TryParse(str, System.Globalization.CultureInfo.GetCultureInfo("tr-TR"), System.Globalization.DateTimeStyles.None, out date);
                }
            }
            return date;
        }
        /// <summary>
        /// Tarihi string ifadeye çevirmeye "dd.MM.yyyy"
        /// </summary>
        /// <param name="d">tarih</param>
        /// <returns></returns>
        public static string get_string_from_date(DateTime d)
        {
            return d.Date.ToString("dd.MM.yyyy");
        }
        /// <summary>
        /// Tarih ve saati string ifadeye çevirmeye "dd.MM.yyyy HH:mm"
        /// </summary>
        /// <param name="d">tarih</param>
        /// <returns></returns>
        public static string get_string_from_datetime(DateTime d)
        {
            return d.ToString("dd.MM.yyyy HH:mm");
        }
        /// <summary>
        /// Tarihi unix time olarak kullanmak için long a çevirir
        /// </summary>
        /// <param name="date">tarih</param>
        /// <returns></returns>
        public static long get_unix_time(DateTime date)
        {
            System.TimeSpan span = new System.TimeSpan(System.DateTime.Parse("1/1/1970").Ticks);
            System.DateTime time = date.Subtract(span);
            return (long)(time.Ticks / 10000);
        }
    }
}
