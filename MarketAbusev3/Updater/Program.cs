using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            //args[0] processName "Market Abuse"
            //args[1] marketAbuseFileName "Market Abuse.exe" by default
            //args[2] updatedMarketAbuseFileName "Market Abuse Updated.exe" by default
            int counter = 0;
            Console.WriteLine("Market Abuse Update Started");

            foreach (string s in args)
                Console.WriteLine(s);


            if(!File.Exists(args[1]) || !File.Exists(args[2]))
            {
                Console.WriteLine("Missing Update Files!");
                Environment.Exit(0);
            }

            while (IsProcessOpen(args[0]))
            {
                if (counter >= 1000)
                    counter = 0;

                if(counter == 0)
                    Console.WriteLine("Waiting for Market Abuse to close");

                counter++;
            }

            File.Delete(args[1]);
            File.Copy(args[2], args[1]);
            File.Delete(args[2]);

            Console.WriteLine("Launching Updated Market Abuse");

            Process.Start(args[1]);

            Console.WriteLine("Update Complete");
        }

        public static bool IsProcessOpen(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
