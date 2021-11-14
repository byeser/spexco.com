using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace spexco.com.restapi.Models
{
    /// <summary>
    /// Generic request 
    /// </summary>
    [DataContract]
    public class apigenericrequest
    {
        /// <summary>
        /// Tablo adi
        /// </summary>
        public string tablename { get; set; }
        /// <summary>
        /// Sayfalama yapılacaksa true ,yapılmayacaksa false döner
        /// </summary>
        public bool paging { get; set; }
        /// <summary>
        /// başlangıç sayfası
        /// </summary>
        public int pageindex { get; set; }
        /// <summary>
        /// sayfa boyutu
        /// </summary>
        public int pagesize { get; set; }
        /// <summary>
        /// Getirilmesi istenilen alanlar
        /// </summary>
        public List<string> seletedfileds { get; set; }
        /// <summary>
        /// Sıralamalar
        /// </summary>
        public orderby orderby { get; set; }

        /// <summary>
        /// Filtrelenecek kriterlerin grouplanması
        /// </summary>
        public predicate predicates { get; set; }
    }
    /// <summary>
    /// Sıralama
    /// </summary>
    public class orderby
    {
        /// <summary>
        /// Sıralanacak field ismi
        /// </summary>
        public string fieldname { get; set; }
        /// <summary>
        /// Sıralama Türü ASC, DESC
        /// </summary>
        public string type { get; set; }
    }
 
   
    /// <summary>
    /// sorgular
    /// </summary>
    public class predicate
    {
        /// <summary>
        /// AND yada OR operatörü
        /// </summary>
        public string logicaloperators { get; set; } = "AND";
        /// <summary>
        /// filtreleme kriteri
        /// </summary>
        public List<filters> filters { get; set; }
    }
    /// <summary>
    /// Filtreleme alanları
    /// </summary>
    public class filters
    {
        /// <summary>
        /// Filtrelenecek alan
        /// </summary>
        public string fieldname { get; set; }
        /// <summary>
        /// Filtreleme durumu
        /// </summary>
        public string operators { get; set; } = "=";
        /// <summary>
        /// Filtrelenecek deger 1
        /// </summary>
        public object value1 { get; set; }
        /// <summary>
        /// Filtrelenecek deger 2
        /// </summary>
        public object value2 { get; set; }
    }
}
