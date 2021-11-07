using spexco.com.ui;
using spexco.com.ui.Models;
using spexco.com.ui.Models.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace spexco.com.ui.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult Login()
        {
            var ajaxRequest = HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (ajaxRequest)
                return PartialView("/Views/Account/LoginForm.cshtml");
            else
                return View();
        }
        [HttpPost]
        public PartialViewResult Login(LoginRequest request, string returnURL)
        { 
            var data = utils.service.helper<ApiResponse<LoginResponse>>.get_api_client(utils.enums.http_protocol.post, "/api/v1/Account/Login", request, false, null).Result;
            if (data.code == (int)HttpStatusCode.OK)
            {
                utils.session.helper<LoginResponse>.add(HttpContext, data.data, utils.ux.helper.session_user); 
                if (Url.IsLocalUrl(returnURL) && returnURL.Length > 0 && returnURL.StartsWith("/") && !returnURL.StartsWith("//") && !returnURL.StartsWith("/\\"))
                    return PartialView("/Views/Account/LoginSuccess.cshtml", returnURL);
                else
                    return PartialView("/Views/Account/LoginSuccess.cshtml", "/Operations/Clients/Products");
            }
            else
                return PartialView("/Views/Account/LoginError.cshtml", new utils.partial.notify() { typ = utils.enums.notify.error, title = "Bilgi Ekranı", description = "Kullanıcı adı veya şifreniz hatalı." + DateTime.Now.ToString() });

        }
       
        public ActionResult LogOut()
        {
            utils.session.helper<LoginResponse>.remove(HttpContext, utils.ux.helper.session_user);
            return RedirectToAction("Login", "Account");
        }
    }
}
