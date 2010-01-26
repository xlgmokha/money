using System;
using System.IO;
using System.Threading;
using gorilla.commons.utility;

namespace Gorilla.Commons.Infrastructure.Logging
{
    public class TextLogger : Logger
    {
        readonly TextWriter writer;

        public TextLogger(TextWriter writer)
        {
            this.writer = writer;
        }

        public void informational(string formatted_string, params object[] arguments)
        {
            writer.WriteLine(formatted_string, arguments);
        }

        public void debug(string formatted_string, params object[] arguments)
        {
            writer.WriteLine("[{0}] - {1}", Thread.CurrentThread.ManagedThreadId,
                             formatted_string.formatted_using(arguments));
        }

        public void error(Exception e)
        {
            writer.WriteLine("{0}", e);
        }
    }
}