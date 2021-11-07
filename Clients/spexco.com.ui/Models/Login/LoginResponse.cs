using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spexco.com.ui.Models.Login
{
    [Serializable]
    public class LoginResponse
    {
        public string id { get; set; }
        public string namesurname { get; set; }
        public string tokentype { get; set; } = "Bearer ";
        public string token { get; set; }
    }
}
