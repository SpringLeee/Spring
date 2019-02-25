using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Core.MVC.Data;
using Core.MVC.Model;
using Core.MVC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Core.MVC
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration; 
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
           
            var connectionString = _configuration["ConnectionStrings:LocalDB"];
            services.AddDbContext<DataContext>(options => { 
                options.UseSqlServer(connectionString);
            });

            services.AddMvc();
            services.AddScoped<IRepository<Student>, EFCoreRepository>();
            //services.AddTransient<IWelCome, Welcome>();  // 每次调用
            //services.AddScoped<IWelCome, Welcome>();   // 每次http请求 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILogger<Startup> logger)
        { 
            // 开发显示错误页面
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
             


            // 引入静态资源文件 
            //app.UseStaticFiles();
            //app.UseDefaultFiles(); 
            app.UseFileServer(); 


            app.UseMvc(build => {
                build.MapRoute("Default","{controller=Home}/{action=Index}/{id?}");
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("hello world");
            //}); 



            //app.Use(next =>
            //{

            //    logger.LogInformation("====== app.Use =======");
            //    return async HttpContext =>
            //    {

            //        logger.LogInformation("======  async HttpContext  =====");
            //        if (HttpContext.Request.Path.StartsWithSegments("/first"))
            //        {
            //            logger.LogInformation(" ====== first ===== ");
            //            await HttpContext.Response.WriteAsync("First");
            //        }
            //        else
            //        {
            //            await HttpContext.Response.WriteAsync("Other");
            //        }
            //    };

            //});

        } 

    } 
  
}
