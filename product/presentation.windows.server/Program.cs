using System;
using Gorilla.Commons.Infrastructure.Container;
using presentation.windows.common;

namespace presentation.windows.server
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper.run();
            Console.ReadLine();
            Resolve.the<Receiver>().stop();
        }
    }
}