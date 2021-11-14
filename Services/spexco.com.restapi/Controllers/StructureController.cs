using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spexco.com.restapi.Models;

namespace spexco.com.restapi.Controllers
{

    /// <summary>
    /// Dinamik yapı
    /// </summary> 
    [ApiController]
    [Route("api/v1/[controller]")]
    [EnableCors("AllowOrigin")]
    [Produces("application/json")]
    public class StructureController : ControllerBase
    {
        /// <summary>
        /// Tablo ismine göre kayıt getirir.
        /// </summary> 
        /// <param name="request">Sorgu kriterleri</param>
        /// <remarks>
        /// Açıklama
        ///
        ///     GET/url
        ///     Endpointi çağırırken tablo adı ,kriterler ve sayfalama yaparak response olarak döner.
        ///
        /// </remarks>
        /// <returns></returns>

        [Route("DynamicQuery")]
        [HttpPost]
        public Task<apiresponse<dynamic>> DynamicQuery(apigenericrequest request)
        {
            var t = new Task<apiresponse<dynamic>>(() =>
            {
                var response = new apiresponse<dynamic>();
                try
                {
                    if (request == null)
                        throw new Exception("Geçersiz parametre!");

                    response = utils.ux.helper.get_query(request);
                    return response;
                }
                catch (Exception ex)
                {
                    response.code = 500;
                    response.errors.Add(ex.Message);
                    return response;
                }

            });
            t.Start();
            return t;

        }
    }
}