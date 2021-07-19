using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;

namespace RamTest
{
    internal class Program
    {
        private static Process[] _process;

        private static void Main()
        {
            Timer timer = new Timer(3000);
            timer.Elapsed += Yaz;
            timer.Start();
            Console.ReadKey();
        }

        private static void Yaz(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            List<string> processModules = new List<string>();
            processModules.Clear();
            try
            {
                _process = Process.GetProcessesByName("discord");
                foreach (Process proces in _process)
                {
                    foreach (ProcessModule module in proces.Modules)
                    {
                        //Console.WriteLine("App: " + proces.ProcessName + " Dll:" + module.ModuleName + "Dll1:" + module.ModuleMemorySize);
                        //Console.WriteLine(" Dll:" + module.ModuleName);
                        processModules.Add(module.ModuleName);
                    }
                }

                Console.WriteLine($"Proses: {_process[0].ProcessName}\tModul Sayısı: {processModules.Count}\tHash: {GetSequenceHashCode(processModules)}");
                Console.WriteLine("--------------------------------------------------------------------");
            }
            catch 
            {
                Console.WriteLine("Uygulama açık değil.");
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
