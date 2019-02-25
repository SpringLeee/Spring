using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.MVC.Controllers
{
    [Route("[controller]/[action]")]
    public class AboutController
    {
        //[Route("Me")]
        //[Route("action")]
        public string Me()
        {
            return "Me.....";
        }
        
        //[Route("You")]
        //[Route("action")]
        public string You()
        {
            return "You...";
        } 
    }
}
