using System;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.Logging;
using presentation.windows.common;

namespace presentation.windows.server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += (o, e) =>
                {
                    (e.ExceptionObject as Exception).add_to_log();
                };
                Bootstrapper.run();
                Console.ReadLine();
                Resolve.the<Receiver>().stop();
            }
            catch (Exception e)
            {
                e.add_to_log();
                //Console.ReadLine();
            }
        }
    }
}