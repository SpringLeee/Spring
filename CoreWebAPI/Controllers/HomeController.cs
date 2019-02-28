using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {   
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { code = 0, msg = "处理成功", data = "/Home/Index" });
        } 


        [HttpGet]
        public IActionResult Order()
        {
            return Ok(new { code = 0, msg = "处理成功", data = "/Home/Order" });
        }

        [HttpPost]
        public IActionResult Mall(MallEntity mall)
        {
            return Ok(new { code = 0, msg = "处理成功", data = mall });
        }


    }
}