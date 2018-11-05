using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartz.Net.Job
{
    public abstract class BaseJob : IJob
    { 
        /// <summary>
        /// cronLike 表达式
        /// </summary>
        public abstract string  cron { get; }

        public abstract Task Execute(IJobExecutionContext context);
    }
}
