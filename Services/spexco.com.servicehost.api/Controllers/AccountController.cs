using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using spexco.com.servicehost.api.RequestResponse;
using spexco.com.servicehost.api.RequestResponse.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace spexco.com.servicehost.api.Controllers
{
    /// <summary>
    /// Kullanıcı Girişi  ve Yetkilendirme
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    [EnableCors("AllowOrigin")]
    [Produces("application/json")]
    public class AccountController : AuthController
    {
        public AccountController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        /// <summary>
        /// Kullanıcı girişi - Girişiniz başarılı ise  kullanıcı bilgileri ile beraber token üretir
        /// </summary>
        /// <param name="request"></param>
        /// <remarks>
        /// Açıklama
        ///
        ///     POST /Login
        ///     Login Token ile birlikte Kullanıcı bilgilerini getirir.
        ///
        /// </remarks>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("Login")]
        public Task<ApiResponse<GetLoginDTO>> Login([FromBody] LoginRequest request)
        {
            var t = new Task<ApiResponse<GetLoginDTO>>(() =>
            {
                var response = new ApiResponse<GetLoginDTO>();
                try
                {
                    if (string.IsNullOrEmpty(request.username) || string.IsNullOrEmpty(request.password))
                        throw new Exception("Hatalı istek! Bilgilerinizi kontrol edin.");

                    var user = spexco.com.datalayer.Repositories.UserRepository.Login(request.username, request.password);
                    if (user == null)
                        throw new Exception("Kullanıcı bilgileriniz yanlış !");

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(spexco.com.modellayer.AppSettings.GetKeyToData<string>("Jwt:key")));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var claims = new List<Claim>()
                    {
                        new Claim(JwtRegisteredClaimNames.Jti,user.username.ToString()),
                        new Claim("UserId",user._id.ToString())
                    };

                    var token = new JwtSecurityToken(
                      spexco.com.modellayer.AppSettings.GetKeyToData<string>("Jwt:issuer"),
                     spexco.com.modellayer.AppSettings.GetKeyToData<string>("Jwt:audience"),
                      claims: claims,
                      expires: DateTime.Now.AddDays(7),
                      notBefore: DateTime.Now,
                      signingCredentials: creds);
                    var data = new GetLoginDTO() { id = user._id.ToString(), namesurname = string.Concat(user.name.firstname, " ", user.name.lastname) };
                    data.token = new JwtSecurityTokenHandler().WriteToken(token);

                    response.data = data;
                    response.code = (int)HttpStatusCode.OK;
                    response.success = new List<string>() { "İşlem başarılı" };
                    response.errors = new List<string>();
                    return response;
                }
                catch (Exception ex)
                {
                    response.code = 500;
                    response.errors = new List<string>() { ex.Message };
                    response.success = new List<string>();
                    return response;
                }

            });
            t.Start();
            return t;

        }
    }
}