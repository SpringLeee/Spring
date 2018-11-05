using Quartz.Impl;
using Quartz.Net.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartz.Net.Untity
{
    /// <summary>
    /// QuartZ 帮助类
    /// </summary>
    public  class QuartzManager
    {

        // 调度器
        private IScheduler scheduler = null; 

        public QuartzManager()
        {
            //初始化调度器

            if (scheduler == null)
            {
                scheduler = new StdSchedulerFactory().GetScheduler().Result; 
            }  
        } 
       
        public void Excute<T>() where T:BaseJob,new ()
        { 
            var cron = new T().cron; 

            if (CronExpression.IsValidExpression(cron))
            { 
                var job = JobBuilder.Create<T>().Build();

                var trigger = TriggerBuilder.Create().WithCronSchedule(cron).Build();

                scheduler.ScheduleJob(job, trigger);
                  
            }   
        }

        public void Start()
        {
            scheduler.Start();
        }


    }
}
