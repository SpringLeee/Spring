using Core.MVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.MVC.Services
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetList();

        void Add(T t);

    }
}
