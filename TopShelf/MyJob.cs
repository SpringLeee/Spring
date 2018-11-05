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
    public class MyJob : ServiceControl
    {
        public bool Start(HostControl hostControl)
        {

            var Job = new QuartzManager(); 
            Job.Excute<Job1>();

            Job.Start();

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            throw new NotImplementedException();
        }
    }
}
