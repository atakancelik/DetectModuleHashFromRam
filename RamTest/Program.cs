using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace RamTest
{
    class Program
    {
        
        static Process[] process;
        static void Main(string[] args)
        {
            Timer timer = new Timer(3000);
            timer.Elapsed += yaz;
            timer.Start();
            Console.ReadKey();
        }

        static private void yaz(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            List<string> processModules = new List<string>();
            processModules.Clear();
            try
            {
                process = Process.GetProcessesByName("fivem");
                Console.WriteLine(process[0].ProcessName);
            }
            catch 
            {
                Console.WriteLine("Uygulama açık değil.");
                return;
            }
            try
            {
                foreach (Process proces in process)
                {
                    foreach (ProcessModule module in proces.Modules)
                    {
                        //Console.WriteLine("App: " + proces.ProcessName + " Dll:" + module.ModuleName + "Dll1:" + module.ModuleMemorySize);
                        //Console.WriteLine(" Dll:" + module.ModuleName);
                        processModules.Add(module.ModuleName);
                    }
                }
                
                Console.WriteLine(processModules.Count);
                Console.WriteLine(GetSequenceHashCode(processModules));
                
            }
            catch 
            {
                Console.WriteLine("Hata!");
            }
            
           

        }
        public static int GetSequenceHashCode<T>(IList<T> sequence)
        {
            const int seed = 487;
            const int modifier = 31;

            unchecked
            {
                return sequence.Aggregate(seed, (current, item) =>
                    (current * modifier) + item.GetHashCode());
            }
        }

       
    }
}
