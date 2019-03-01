using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWebAPI.Models;
using CoreWebAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public StudentService service { get; set; }

        public HomeController(StudentService studentService)
        {
            service = studentService;
        }


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

        [HttpGet]
        public IActionResult EFCoreAdd()
        {
            var list = service.GetList().Result;

            return Ok(new { code = 0, msg = "处理成功", data = list });
        } 


    }
}