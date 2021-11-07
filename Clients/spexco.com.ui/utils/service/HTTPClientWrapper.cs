using spexco.com.ui.Models.Login;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace spexco.com.ui.utils.service
{
    /// <summary>
    /// REST API generic sınıf
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class helper<T>
    {
        private static LoginResponse usr = utils.session.helper<LoginResponse>.get(HttpContext.Current, utils.ux.helper.session_user);
        /// <summary>
        /// Api ye gönderilen isteğin sonucunu döndürür.
        /// </summary>
        /// <param name="method">GET,POST,PUT,DELETE metodu gönderilir</param>
        /// <param name="api_url">end point adresi</param>
        /// <param name="request">json a cevilecek class modeli</param>
        /// <param name="is_token"> token kullanılıp kullanılmayacağı</param>
        /// <param name="dict_parameters">parametre kullanılacaksa  deger gönderilir</param>
        /// <returns></returns>
        public static async Task<T> get_api_client(enums.http_protocol method, string api_url, object request = null, bool is_token = true, Dictionary<string, string> dict_parameters = null, Dictionary<string, string> dict_header_parameters = null)
        {            
            T result = default(T);
            string serviceUrl = utils.ux.helper.get_appsettings<string>("AppSettings:serviceUrl");
            var client = new RestClient(string.Concat(serviceUrl, api_url));
            var req = new RestRequest();
            switch (method)
            {
                case enums.http_protocol.get:
                    req.Method = Method.GET;
                    break;
                case enums.http_protocol.post:
                    req.Method = Method.POST;
                    break;
                case enums.http_protocol.put:
                    req.Method = Method.PUT;
                    break;
                case enums.http_protocol.delete:
                    req.Method = Method.DELETE;
                    break;
                default:
                    req.Method = Method.GET;
                    break;
            }
            req.Parameters.Clear();
            req.AddHeader("Accept", "application/json");
            req.AddHeader("Content-Type", "application/json");
            if (dict_header_parameters != null)
                foreach (var item in dict_header_parameters)
                {
                    req.AddHeader(item.Key, item.Value);
                }
            if (is_token == true)
                req.AddHeader("Authorization", string.Concat(usr.tokentype, usr.token));
            if (dict_parameters != null)
                foreach (var item in dict_parameters)
                {
                    req.AddParameter(item.Key, item.Value);
                }
            if (request != null)
                req.AddJsonBody(request);
            var resp = client.Execute(req);
            result = JsonConvert.DeserializeObject<T>(resp.Content);
            return result;
        }
    }
}
