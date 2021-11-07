using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace spexco.com.servicehost.api.Controllers
{
    /// <summary>
    /// Kullanıcı Id si olup olmadını kontrol etmek için oluşturulan Controller
    /// </summary>
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Claims lere erişmek için kullanıldı.
        /// </summary>
        protected static IHttpContextAccessor _httpContextAccessor;
        /// <summary>
        /// Kullanıcı Id si
        /// </summary>
        public string UserId { get; set; }
        public AuthController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            SetUserId();
        }
        /// <summary>
        /// Kullanıcı Id si olup olmadını kontrol eder,Id varsa "UserId" ye set edilir
        /// </summary>
        private void SetUserId()
        {
            if (_httpContextAccessor == null || _httpContextAccessor.HttpContext == null)
                return;

            var identity = _httpContextAccessor.HttpContext.User;

            var id = identity.Claims.SingleOrDefault(c => c.Type == "UserId");

            if (id != null)
                UserId = id.Value;
        }
    }
}