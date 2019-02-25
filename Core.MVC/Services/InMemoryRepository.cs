using Core.MVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.MVC.Services
{
    public class InMemoryRepository : IRepository<Student>
    {
        public IEnumerable<Student> GetList()
        {
            return new List<Student> {

                new Student{ Id =1 , FirstName = "张三" },
                new Student{ Id= 2 , FirstName = "李四" },
                new Student{ Id =3 , FirstName = "王五" }

            };
        }
    }
}
