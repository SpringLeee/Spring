using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.MVC.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Core.MVC.Controllers
{
    public class LoggerController : Controller
    {
        private readonly ILogger<LoggerController> _logger;
        public LoggerController(ILogger<LoggerController> logger)
        {
            _logger = logger;
        }
         
       
        public IActionResult Index()
        {
            _logger.LogInformation(" =========== 这里进入Logger 控制器 =======");


            return Content("Logger...");
        }
    }
}