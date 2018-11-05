using Quartz.Net.Job;
using Quartz.Net.Untity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartz.Net
{
    class Program
    {
        static void Main(string[] args)
        { 
            var Job = new QuartzManager();
            Job.Excute<MyJob>();
            Job.Excute<Job1>(); 

            Job.Start(); 

            Console.ReadKey();
        }
    }
}
