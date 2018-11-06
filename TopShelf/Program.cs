using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;
using System.Timers;
using Topshelf;

namespace TopShelf
{ 

    class Program
    {
        static void Main(string[] args)
        {   
            HostFactory.Run(x=> {

                x.Service<MyJob>(s => { 
                    s.ConstructUsing(p => new MyJob());
                    s.WhenStarted(p => p.Start());
                    s.WhenStopped(p => p.Stop()); 
                });

                x.RunAsLocalSystem();

                x.SetServiceName("MyJob"); 
                x.SetDisplayName("  MyJob DisPaly "); 

            }); 
          
        }
    }


}
