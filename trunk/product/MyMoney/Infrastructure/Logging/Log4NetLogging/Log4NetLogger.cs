using System;
using System.Threading;
using log4net;
using MoMoney.Utility.Extensions;

namespace MoMoney.Infrastructure.Logging.Log4NetLogging
{
    public class Log4NetLogger : ILogger
    {
        readonly ILog log;

        public Log4NetLogger(ILog log)
        {
            this.log = log;
        }

        public void informational(string formattedString, params object[] arguments)
        {
            log.InfoFormat(formattedString, arguments);
        }

        public void debug(string formatted_string, params object[] arguments)
        {
            log.DebugFormat("Thread: {0}, {1}", Thread.CurrentThread.ManagedThreadId, formatted_string.formatted_using(arguments));
        }

        public void error(Exception e)
        {
            log.Error(e.ToString());
        }
    }
}