using Core.MVC.Data;
using Core.MVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.MVC.Services
{
    public class EFCoreRepository : IRepository<Student>
    {
        private readonly DataContext _db;
        public EFCoreRepository(DataContext db)
        {
            _db = db;
        }

        public void Add(Student t)
        {
            _db.Students.Add(t);
            _db.SaveChanges();
        }

        public IEnumerable<Student> GetList()
        {
            return _db.Students.ToList();
        }
    }
}
