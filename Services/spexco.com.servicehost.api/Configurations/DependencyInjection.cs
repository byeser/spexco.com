using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spexco.com.servicehost.api.Configurations
{
    /// <summary>
    /// Startup ta tanımlalar için oluşturuldu ve DI containerler .
    /// </summary>
    public class DependencyInjection
    {
        public DependencyInjection(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor(); 
             
        }
    }
}
