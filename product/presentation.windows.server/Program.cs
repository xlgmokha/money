using System;
using System.Diagnostics;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.Logging;
using MoMoney.Service.Infrastructure.Threading;
using Rhino.Queues;

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
                AppDomain.CurrentDomain.ProcessExit += (o, e) =>
                {
                    "shutting down".log();
                    try
                    {
                        Resolve.the<CommandProcessor>().stop();
                        Resolve.the<IQueueManager>().Dispose();
                    }
                    catch { }
                    Environment.Exit(Environment.ExitCode);
                };
                Bootstrapper.run();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                e.add_to_log();
                if(Debugger.IsAttached) Debugger.Break();
                //Console.ReadLine();
            }
        }
    }
}