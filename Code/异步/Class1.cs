using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Code.异步
{
    public class Class1
    {

        //创建计时器
        private static readonly Stopwatch Watch = new Stopwatch();

        public async void Excute()
        {
            //启动计时器
            Watch.Start();

            const string url1 = "http://www.cnblogs.com/";
            const string url2 = "http://www.cnblogs.com/liqingwen/";

           var a1 = CountCharactersAsync(1,url1);
           var a2 = CountCharactersAsync(2, url2); 

            Console.WriteLine(" a1 : " + a1.Result);
            Console.WriteLine(" a2 : " + a2.Result); 
          

            Console.Read();
        }

        /// <summary>
        /// 统计字符个数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        private static async Task<int> CountCharactersAsync(int id, string address)
        { 
            Console.WriteLine("--------------- " + id + "----------"); 

            var wc = new WebClient();

            var result = await wc.DownloadStringTaskAsync(address); 

            Thread.Sleep(3000);

            Console.WriteLine($" a {id} 完成 ");

            return result.Length;
        }
    }
}
