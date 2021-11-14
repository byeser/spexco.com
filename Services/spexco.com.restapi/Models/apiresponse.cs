using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spexco.com.restapi.Models
{
    /// <summary>
    /// Client için standart bir mesaj dönmesi
    /// </summary>
    /// <typeparam name="T">istenilen data type set edilebilir</typeparam>
    public class apiresponse<T>
    {
        /// <summary>
        /// Constracture ,initiliaze oldugunda listlerin türetilmesi için kullanıldı
        /// </summary>
        public apiresponse()
        {
            success = new List<string>();
            errors = new List<string>();
        }
        /// <summary>
        /// Versiyonu
        /// </summary> 
        public string version { get { return "1.0"; } }
        /// <summary>
        /// Request kodu ,error ,succes etc.
        /// </summary> 
        public int code { get; set; }
        /// <summary>
        /// Hata listesi
        /// </summary> 
        public List<string> errors { get; set; }
        /// <summary>
        /// Başarılı listesi
        /// </summary> 
        public List<string> success { get; set; }
        /// <summary>
        /// Toplam Kayıt Sayısı
        /// </summary>
        public long totalcount { get; set; }
        /// <summary>
        /// Görüntülenen Kayıt Sayısı
        /// </summary>
        public long displayedrecord { get; set; }
        /// <summary>
        /// Response da dönecek olan verinin tipi ; List,int ,bool,string ...etc
        /// </summary> 
        public T data { get; set; }
    }
}
