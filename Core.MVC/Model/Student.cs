using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.MVC.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        [MinLength(10)]
        public string LastName { get; set; }  
    }
}
