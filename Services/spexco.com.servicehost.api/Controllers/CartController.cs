using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using spexco.com.modellayer.mongo;
using spexco.com.servicehost.api.RequestResponse;
using spexco.com.servicehost.api.RequestResponse.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace spexco.com.servicehost.api.Controllers
{
    /// <summary>
    /// Sepet işlemleri
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    [EnableCors("AllowOrigin")]
    [Produces("application/json")]
    public class CartController : AuthController
    {
        public CartController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }


        /// <summary>
        /// Kullanıcının sepetine ürün ekleme. Eğer ürün sepette ekli ise sepetteki adet sayısını arttırır.
        /// </summary> 
        /// <param name="request">Eklenecek ürün ve sayısı</param>
        /// <remarks>
        /// Açıklama
        ///
        ///     GET/url
        ///     Endpointi çağırırken ürün ve sayısını verdiğimiz zaman toplam sepet tutarını response olarak döner.
        ///
        /// </remarks>
        /// <returns></returns>

        [Route("AddProduct")]
        [HttpPost]
        public Task<ApiResponse<AddProductResponse>> AddProduct(AddProductRequest request)
        {
            var t = new Task<ApiResponse<AddProductResponse>>(() =>
            {
                var response = new ApiResponse<AddProductResponse>();
                try
                {
                    if (string.IsNullOrEmpty(UserId))
                        throw new Exception("Kullanıcı bilgilerine erişilemedi!");

                    if (request == null || request.products == null || request.products.Count == 0)
                        throw new Exception("Geçersiz parametre!");

                    if (request.products.Where(x => x.quantity <= 0).Count() > 0)
                        throw new Exception("Ürün adet bilgisi geçersiz!");

                    var cart = datalayer.Repositories.CartRepository.GetUserCart(UserId);

                    var products = datalayer.Repositories.ProductRepository.GetAllPaging().ToDictionary(x => x._id.ToString(), y => y);
                    double total = 0;

                    foreach (var item in request.products)
                    {
                        var productOnCart = cart.products.Where(x => x._id.ToString() == item.id).FirstOrDefault();
                        if (productOnCart != null)
                        { 
                            cart.products.Remove(productOnCart);
                            cart.products.Add(new CartProduct() { _id = ObjectId.Parse(item.id), quantity = item.quantity + productOnCart.quantity });

                            total += products[item.id].price * (item.quantity + productOnCart.quantity);
                        }
                        else
                        {
                            cart.products.Add(new CartProduct() { _id = ObjectId.Parse(item.id), quantity = item.quantity });

                            total += products[item.id].price * item.quantity;
                        }
                    }
                    datalayer.Repositories.CartRepository.Update(cart);


                    response.data = new AddProductResponse() { totalPrice = total };
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
        /// Kullanıcının sepetteki ürünlerini getirir.
        /// </summary> 
        /// <remarks>
        /// Açıklama
        ///
        ///     GET/url
        ///     Endpointi çağırırken sepetteki ürünler response olarak döner.
        ///
        /// </remarks>
        /// <returns></returns>

        [Route("Get")]
        [HttpGet]
        public Task<ApiResponse<GetCartProducts>> Get()
        {
            var t = new Task<ApiResponse<GetCartProducts>>(() =>
            {
                var response = new ApiResponse<GetCartProducts>();
                try
                {
                    if (string.IsNullOrEmpty(UserId))
                        throw new Exception("Kullanıcı bilgilerine erişilemedi!");

                    var cart = datalayer.Repositories.CartRepository.GetUserCart(UserId);
                    var products = datalayer.Repositories.ProductRepository.GetAllPaging().ToDictionary(x => x._id.ToString(), y => y);

                    var data = new GetCartProducts();
                    double total = 0;
                    foreach (var item in cart.products)
                    {
                        var prod = products[item._id.ToString()];
                        total += prod.price * item.quantity;
                        data.products.Add(new CartProductDTO() { quantity = item.quantity, name = prod.title, description = prod.description, images = prod.image, price = prod.price * item.quantity, productId = item._id.ToString() });
                    }
                    data.total = total;

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
    }
}