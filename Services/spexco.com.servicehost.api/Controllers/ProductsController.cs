using spexco.com.servicehost.api.RequestResponse;
using spexco.com.servicehost.api.RequestResponse.Cart;
using spexco.com.servicehost.api.RequestResponse.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace spexco.com.servicehost.api.Controllers
{
    /// <summary>
    /// Ürün işlemleri
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    [EnableCors("AllowOrigin")]
    [Produces("application/json")]
    public class ProductsController : AuthController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public ProductsController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        /// <summary>
        /// Seçili ürünün detayını getirir
        /// </summary> 
        /// <param name="id">Ürün Id si</param>
        /// <remarks>
        /// Açıklama
        ///
        ///     GET/url
        ///     Endpointi çağırdığımızda ürüne ait detayı response olarak döner
        ///
        /// </remarks>
        /// <returns></returns>

        [Route("Get/{id}")]
        [HttpGet]
        public Task<ApiResponse<GetProduct>> Get(string id)
        {
            var t = new Task<ApiResponse<GetProduct>>(() =>
            {
                var response = new ApiResponse<GetProduct>();
                try
                {
                    if (string.IsNullOrEmpty(id))
                        throw new Exception("Ürün Id si boş geçilemez !");

                    if (string.IsNullOrEmpty(UserId))
                        throw new Exception("Kullanıcı bilgilerine erişilemedi!");

                    var products = datalayer.Repositories.ProductRepository.GetById(id);
                    if (products==null)
                    {
                        response.code = (int)HttpStatusCode.OK;
                        response.success.Add("İşlem başarılı");
                        return response;
                    }
                    var data =  new GetProduct()
                    {
                        id = products._id.ToString(),
                        category = products.category,
                        description = products.description,
                        image = products.image,
                        price = products.price,
                        title = products.title,
                        rating = new rating() { count = products.rating.count, rate = products.rating.rate }
                    };

                    response.data = data;
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
        /// <summary>
        /// Ürünleri sayfalama yaparak listeler.
        /// </summary> 
        /// <remarks>
        /// Açıklama
        ///
        ///     GET/url
        ///     Endpointi çağırdığımızda ürünler sayfalanarak listelenir response olarak döner
        ///
        /// </remarks> 
        /// <param name="category">Ürün kategorisi</param>
        /// <param name="size">Kayıt Sayısı</param>
        /// <param name="page">Sayfa</param>
        /// <param name="order">Sıralama Şekli</param>
        /// <returns></returns>

        [Route("GetAll")]
        [HttpGet]
        public Task<ApiResponse<GetProducts>> GetAll(string category = "",  int size = 10, int page = 1, string order = "asc")
        {
            var t = new Task<ApiResponse<GetProducts>>(() =>
            {
                var response = new ApiResponse<GetProducts>();
                try
                {
                    if (string.IsNullOrEmpty(UserId))
                        throw new Exception("Kullanıcı bilgilerine erişilemedi!");

                    var products = datalayer.Repositories.ProductRepository.GetAllPaging(category,size,page,order);
                    if (products.Count == 0)
                    {
                        response.code = (int)HttpStatusCode.OK;
                        response.success.Add("İşlem başarılı");
                        return response;
                    }
                    var data = products.Select(x => new GetProduct()
                    {
                        id = x._id.ToString(),
                        category = x.category,
                        description = x.description,
                        image = x.image,
                        price = x.price,
                        title = x.title,
                        rating = new rating() { count = x.rating.count, rate = x.rating.rate }
                    });
                    var count = datalayer.Repositories.ProductRepository.GetAllPagingCount(category);

                    response.data = new GetProducts() { products = data.ToList(), count = count };
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