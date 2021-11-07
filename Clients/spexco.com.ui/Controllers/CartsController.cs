using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using spexco.com.ui.Models.Login;
using Microsoft.AspNetCore.Mvc;

namespace spexco.com.ui.Controllers
{
    public class CartsController : Controller
    {
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
    }
}