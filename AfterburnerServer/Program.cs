using System;
using System.Diagnostics;
using MSI.Afterburner;
using AfterburnerServer.Networking;

namespace AfterburnerServer
{
    internal class Program
    {
        private const string SERVER_URL = "http://localhost:3000";

        public static bool Alive { get; set; }
        public static Process NodeProcess;

        private static void Main(string[] args)
        {
            Alive = true;

            // Connect to HardwareMonitor shared memory
            var hardwareMonitor = new HardwareMonitor();

            // Start the server
            new Server(SERVER_URL, hardwareMonitor);

            //                // show a data source monitor several times
            //                HardwareMonitorEntry framerate = hardwareMonitor.GetEntry(HardwareMonitor.GPU_GLOBAL_INDEX, MONITORING_SOURCE_ID.FRAMERATE);
            //                if (framerate != null)
            //                {
            //                    Console.WriteLine("***** FRAMERATE *****");
            //                    for(var i = 0; i < 10; i++)
            //                    {
            //                        Console.WriteLine(framerate.Data);
            //                        System.Threading.Thread.Sleep(1000);
            //                        hardwareMonitor.ReloadEntry(framerate);
            //                    }
            //                }

            Console.WriteLine("SERVER IS RUNNING");
            Console.ReadKey();

            // Stop the stat sending thread
            Alive = false;
        }
    }
}
