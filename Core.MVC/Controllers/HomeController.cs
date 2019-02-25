using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.MVC.Controllers
{
    public class HomeController
    {
        public string Index(int id = 0)
        {
            return $"Home....id:{id}";
        } 
    }
}
