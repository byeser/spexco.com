using spexco.com.ui.Models.Login;
using Microsoft.AspNetCore.Mvc; 

namespace spexco.com.ui.Controllers
{
    public class OperationsController : Controller
    {
        /// <summary>
        /// Tüm sayfasların üzerinde durması için oluşturulan cshtml sayfası
        /// </summary>
        /// <returns></returns>
        public IActionResult Clients()
        {
            var usr = utils.session.helper<LoginResponse>.get(HttpContext, utils.ux.helper.session_user);
            if (usr != null)
            {
                var ajaxRequest = HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
                if (ajaxRequest)
                    return PartialView();
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