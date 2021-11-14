using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using spexco.com.restapi.OAuth;

namespace spexco.com.restapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1.0",
                    Title = "Rest Full Service",
                    Description = "Spexco",
                    TermsOfService = new Uri("https://muhammeteser.com.tr"),
                    Contact = new OpenApiContact
                    {
                        Name = "Muhammet ESER",
                        Email = "esermuhammet@hotmail.com",
                        Url = new Uri("https://muhammeteser.com.tr"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Muhammet ESER",
                        Url = new Uri("https://muhammeteser.com.tr"),
                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Auth olmak için Bearer tokený burda kullanýnýz",
                });
                //kod belgeleyici yolu
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.OperationFilter<AddAuthorizationHeaderParameterOperationFilter>();
                c.IncludeXmlComments(xmlPath);
            });

         
            services.AddMvcCore(options =>
            {
                options.EnableEndpointRouting = false;

            }).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);

            services.AddHttpContextAccessor();
            services.AddControllers();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", "Spexco API");
                c.InjectStylesheet("/SwaggerCustom.css");
                c.InjectJavascript("/SwaggerCustom.js");
            });

            app.UseRouting();
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseStaticFiles();



            app.UseAuthentication();

            app.UseAuthorization();
            app.UseResponseCaching();
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Xss-Protection", "1;mode=block");// 1:Xss active ,Reflected  XSS durumunda sanitize yapmadan direk render iþlemini engeller

                await next();
            });

            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    name: "home",
                    template: "{controller}/{action}"
                    );
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
