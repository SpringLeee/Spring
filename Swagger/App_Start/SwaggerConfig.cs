using System.Web.Http;
using WebActivatorEx;
using Swagger;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Swagger
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    { 
                        c.SingleApiVersion("v1", "Swagger");

                        c.IncludeXmlComments($"{ System.AppDomain.CurrentDomain.BaseDirectory}/bin/Swagger.xml");

                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DocumentTitle("系统开发接口");

                        // 使用中文
                        c.InjectJavaScript(thisAssembly, "Com.App.SysApi.Scripts.Swagger.swagger_lang.js");
                    });
        } 
    }
}
