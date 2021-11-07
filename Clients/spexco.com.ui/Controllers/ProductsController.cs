using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using spexco.com.ui.Models;
using spexco.com.ui.Models.Cart;
using spexco.com.ui.Models.Login;
using Microsoft.AspNetCore.Mvc;
using spexco.com.ui.Models.Product;

namespace spexco.com.ui.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var usr = utils.session.helper<LoginResponse>.get(HttpContext, utils.ux.helper.session_user);
            if (usr != null)
            {
                var ajaxRequest = HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
                if (ajaxRequest)
                    return PartialView("Index", new Models.generate_response<int>() { data = 1, notify = new utils.partial.notify() { typ = utils.enums.notify.none, title = "Uyarı", description = "Başarıyla Listelenmiştir" } });
                else
                    return View();
            }
            else
            {
                #region not login
                var ajaxRequest = HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
                if (ajaxRequest)
                    return PartialView("/Views/Shared/_Redirect.cshtml", "/Account/Login");
                else
                    return RedirectToAction("Login", "Account");
                #endregion
            }
        }
        public IActionResult _List()
        {
            var usr = utils.session.helper<LoginResponse>.get(HttpContext, utils.ux.helper.session_user);
            if (usr != null)
            {
                var ajaxRequest = HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
                if (ajaxRequest)
                    return PartialView("_List", new Models.generate_response<int>() { data = 1, notify = new utils.partial.notify() { typ = utils.enums.notify.none, title = "Uyarı", description = "Başarıyla Listelenmiştir" } });
                else
                    return View();
            }
            else
            {
                #region not login
                var ajaxRequest = HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
                if (ajaxRequest)
                    return PartialView("/Views/Shared/_Redirect.cshtml", "/Account/Login");
                else
                    return RedirectToAction("Login", "Account");
                #endregion
            }
        }
        /// <summary>
        /// Ürün sayfamala 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult _ListPage()
        {
            var usr = utils.session.helper<LoginResponse>.get(HttpContext, utils.ux.helper.session_user);
            if (usr != null)
            {
                int draw = Convert.ToInt32(Request.Form["draw"]);
                int start = Convert.ToInt32(Request.Form["start"]);
                int length = Convert.ToInt32(Request.Form["length"]);
                string query = Request.Form["search[value]"];
                int page = (start / length) + 1;
                string sortDirection = "DESC";
                if (Request.Form["order[0][dir]"].ToString() != "")
                    sortDirection = Request.Form["order[0][dir]"];

                string category = "";
                if (Request.Form["filterByDate"] == "true")
                {
                    category = Request.Form["category"] == "all" ? "" : Request.Form["category"].ToString();
                }

                string parameters = string.Concat("?category=", category, "&size=5&page=", page, "&order=asc");

                long count = 0;
                var result = spexco.com.ui.utils.service.helper<spexco.com.ui.Models.generate_response<spexco.com.ui.Models.Product.ProductResponse>>.get_api_client(spexco.com.ui.utils.enums.http_protocol.get, "/api/v1/Products/GetAll" + parameters, null, true, null, null).Result.data;


                count = result.count;
                int sortColumn = -1;

                if (Request.Form["order[0][column]"].ToString() != "")
                {
                    sortColumn = int.Parse(Request.Form["order[0][column]"]);
                }


                var totalRecord = count;// result.vRows.Count();
                var model = result.products;// result.vRows.Skip((page - 1) * 15).Take(15).ToList();
                int pageRecord = result.products.Count();

                return Json(new { data = model, draw = Request.Form["draw"], recordsTotal = pageRecord, recordsFiltered = totalRecord });
            }
            else
                return Json(new { data = new List<Product>(), draw = Request.Form["draw"], recordsTotal = 0, recordsFiltered = 0 });
        }
        public IActionResult _AddCart(string id)
        {
            var usr = utils.session.helper<LoginResponse>.get(HttpContext, utils.ux.helper.session_user);
            if (usr != null)
            {
                var request = new AddProductRequest();
                request.products = new List<AddProductItem>();
                request.products.Add(new AddProductItem() { id = id, quantity = 1 });
                var result = utils.service.helper<ApiResponse<AddProductResponse>>.get_api_client(utils.enums.http_protocol.post, "/api/v1/Cart/AddProduct", request, true, null, null).Result;
                if (result.errors.Count() != 0)
                    return PartialView("_List", new Models.generate_response<int>()
                    {
                        data = 0,
                        notify = new utils.partial.notify()
                        {
                            typ = utils.enums.notify.error,
                            title = "Bilgi Ekranı",
                            description = result.errors.FirstOrDefault()
                        }
                    });
                return PartialView("Index", new Models.generate_response<int>()
                {
                    data = 0,
                    notify = new utils.partial.notify()
                    {
                        typ = utils.enums.notify.success,
                        title = "Bilgi Ekranı",
                        description = "Ürün sepete eklenmiştir."
                    }
                });
            }
            else
            {
                #region not login
                return PartialView("/Views/Shared/_Redirect.cshtml", "/Account/Login");
                #endregion
            }
        }
    }
}