using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spexco.com.servicehost.api.RequestResponse;

namespace spexco.com.servicehost.api.Controllers
{
    /// <summary>
    /// Kategori işlemleri
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    [EnableCors("AllowOrigin")]
    [Produces("application/json")]
    public class CategoryController : AuthController
    {
        public CategoryController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        /// <summary>
        /// Kategori listesini getirir.
        /// </summary> 
        /// <remarks>
        /// Açıklama
        ///
        ///     GET/url
        ///     Endpointi çağırırken kategori listesi response olarak döner.
        ///
        /// </remarks>
        /// <returns></returns>
        [Route("GetAll")]
        [HttpGet]
        public Task<ApiResponse<List<string>>> GetAll()
        {
            var t = new Task<ApiResponse<List<string>>>(() =>
            {
                var response = new ApiResponse<List<string>>();
                try
                {
                    if (string.IsNullOrEmpty(UserId))
                        throw new Exception("Kullanıcı bilgilerine erişilemedi!");

                    var categories = datalayer.Repositories.ProductRepository.GetCategoriesList();
                    categories.Add("all");
                    response.data = categories;
                    response.code = (int)HttpStatusCode.OK;
                    response.success.Add("İşlem başarılı");
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