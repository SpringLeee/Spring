using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace Core.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        { 
           
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext().
                WriteTo.Console().WriteTo.File(new Serilog.Formatting.Json.JsonFormatter(), @"Logs\log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();


            WebHost.CreateDefaultBuilder(args)
                .UseSerilog()
                .UseStartup<Startup>().Build().Run();
        } 
           
    }
}
