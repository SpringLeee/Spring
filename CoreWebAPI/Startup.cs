using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks; 
using CoreWebAPI.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace CoreWebAPI
{

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        { 

            // 注册上下文
            services.AddDbContext<LocalDBContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("LocalDB"))
             ); 

            // 注册Service
            services.AddScoped<StudentService>();

            //添加Swagger 文档
            services.AddSwaggerGen(c =>
            {
                //标题信息
                c.SwaggerDoc("v1", new Info { Title = "CoreWebAPI", Version = "v1" });

                // 启用注释
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath); 

            }); 



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
             
           
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            
            //使用Swagger
            app.UseSwagger(); 
         
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoreWebAPI"); 
            }); 
           

            app.UseMvc();
        }
    }
}
