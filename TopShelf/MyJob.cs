using Quartz.Net.Untity;
using Quartz.Net.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TopShelf
{
    public class MyJob 
    {  

        public void Start()
        {
            var Job = new QuartzManager();
            Job.Excute<Job1>();

            Job.Start();
        }

        public void Stop()
        {

        } 
    }
}
