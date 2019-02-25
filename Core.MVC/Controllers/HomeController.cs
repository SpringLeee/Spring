using Core.MVC.Model;
using Core.MVC.Services;
using Core.MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Student> _repository;


        public HomeController(IRepository<Student> repository)
        {
            this._repository = repository;
        }

        public IActionResult Index(int id = 0)
        {
            //this.ControllerContext.ActionDescriptor.ActionName; 
            return this.Content("Home...");
        }

        public IActionResult GetStudent()
        {
            var st = new Student {
                Id = 1,
                FirstName = "张",
                LastName = "三"
            };

            //return new JsonResult(st);
            return new ObjectResult(st);
        }

        public IActionResult GetView()
        {
            //var st = new Student
            //{
            //    Id = 1,
            //    FirstName = "张",
            //    LastName = "三"
            //};
            //return View(st);


            var list = _repository.GetList();
            var vmList = list.Select(x => new StudentViewModel {
                Id = x.Id,
                Name = x.FirstName + x.LastName,
                Age = 15 
            });

            return View(vmList);  

        }

        public IActionResult Detail(int id)
        { 

            return View(_repository.GetList().Where(x => x.Id == id).Select(x=> new StudentViewModel { Id = x.Id,Name = x.FirstName + x.LastName, Age = 10 }).FirstOrDefault());
        }


    }
}
