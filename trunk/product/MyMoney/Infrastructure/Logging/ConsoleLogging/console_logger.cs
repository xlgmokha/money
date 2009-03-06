using System;
using System.IO;

namespace MoMoney.Infrastructure.Logging.ConsoleLogging
{
    public class console_logger : ILogger
    {
        private readonly TextWriter writer;

        public console_logger() : this(Console.Out)
        {}

        public console_logger(TextWriter writer)
        {
            this.writer = writer;
        }

        public void informational(string formattedString, params object[] arguments)
        {
            writer.WriteLine(formattedString, arguments);
        }

        public void debug(string formattedString, params object[] arguments)
        {
            writer.WriteLine(formattedString, arguments);
        }

        public void error(Exception e)
        {
            writer.WriteLine("{0}", e);
        }
    }
}