using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Core.MVC.wwwroot.Controllers
{
    public class HomeController
    {
        public string Index()
        {
            return "/Home/Index";
        }
    }
}