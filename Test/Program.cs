using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 对象引用
            string a = "1";
            string b = a;

            Console.WriteLine("===== 引用类型分配 ======");

            Console.WriteLine(a.GetHashCode());
            Console.WriteLine(b.GetHashCode());

            string a1 = "1";
            string b1 = "1";

            Console.WriteLine("=============");

            Console.WriteLine(a1.GetHashCode());
            Console.WriteLine(b1.GetHashCode());

            Console.ReadKey();
            #endregion 




        }
    }
}
