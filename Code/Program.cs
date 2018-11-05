using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Code
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();

            for (int i = 0; i < 10000; i++)
            {
                list.Add(i);
            }

            Parallel.ForEach(list, new ParallelOptions { MaxDegreeOfParallelism = 10}, o=> {


                Thread.Sleep(5000);


                Console.WriteLine(o); 

            });


            Console.ReadKey();

        }
    }
}
