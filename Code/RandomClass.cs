using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Code
{
    public class RandomClass
    {

        public void Test1()
        {
            
            List<int> list = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            List<int> a1 = new List<int>(); 

            for (int i = 0; i < 100; i++)
            {
                 
                a1.Add(new Random(i*99999999).Next(0,100)); 
            }

            Console.WriteLine(" ============================= ");

           

            for (int i = 0; i < 100; i++)
            {
                Console.Write($"{a1[i]}:{i},"); 
            }
  
           

            Console.WriteLine(" ============================= ");

            Console.WriteLine(string.Join(",", a1.OrderBy(x=>x)));

            Console.WriteLine(" ============================= ");

            Console.WriteLine(string.Join(",", list));


            Console.WriteLine(new Random(5*9992).Next(0,100));

            Console.WriteLine(new Random(77 * 9992).Next(0, 100));





        } 




    }
}
