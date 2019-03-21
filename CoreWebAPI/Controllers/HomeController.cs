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
    /// <summary>
    /// 首页控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController] 
    public class HomeController : ControllerBase
    {
        public StudentService service { get; set; }

        public HomeController(StudentService studentService)
        {
            service = studentService;
        }


        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [HttpGet]  
        public IActionResult Index()
        {
            return Ok(new { code = 0, msg = "处理成功", data = "/Home/Index" });
        } 

        /// <summary>
        /// 订单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Order()
        {
            return Ok(new { code = 0, msg = "处理成功", data = "/Home/Order" });
        }

        /// <summary>
        /// 商城数据
        /// </summary>
        /// <param name="mall"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Mall(MallEntity mall)
        {
            return Ok(new { code = 0, msg = "处理成功", data = mall });
        }


        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EFCoreAdd()
        {
            var list = service.GetList().Result;

            return Ok(new { code = 0, msg = "处理成功", data = list });
        } 


    }
}