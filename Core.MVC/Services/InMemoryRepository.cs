using Core.MVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.MVC.Services
{
    public class InMemoryRepository : IRepository<Student>
    { 
        private readonly List<Student> _students;
        public InMemoryRepository()
        {
            _students = new List<Student> {

                new Student{ Id =1 , FirstName = "张三" },
                new Student{ Id= 2 , FirstName = "李四" },
                new Student{ Id =3 , FirstName = "王五" }

            };
        } 
       

        public void Add(Student student)
        {
            _students.Add(student);
        }

        public IEnumerable<Student> GetList()
        {
            return _students;
        }
    }
}
