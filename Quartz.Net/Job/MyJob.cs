using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartz.Net.Job
{


    //并发执行
    [DisallowConcurrentExecution] 
    public class MyJob : BaseJob
    {   
        public override string cron { get => "0/5 * * * * ?"; } 

        public override Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine(@"

                  __   __  
                /　\./　\/\_　　   MyJob " + DateTime.Now.ToString() + @"
             __{^\_ _}_　 )　}/^\　　　 
            /　/\_/^\._}_/　//　/
            (　(__{(@)}\__}.//_/__A___A______A_______A______A____
            \__/{/(_)\_}　)\\ \\---v----V-----V--Y----v---Y-----
             (　 (__)_)_/　)\ \>　　
              \__/　　 \__/\/\/
               \__,--'　　　　

            ");

            return Task.CompletedTask;

        }
    }
}
