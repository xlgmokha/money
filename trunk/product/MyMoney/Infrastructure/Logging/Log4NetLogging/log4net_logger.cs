using System;
using log4net;

namespace MoMoney.Infrastructure.Logging.Log4NetLogging
{
    public class log4net_logger : ILogger
    {
        private readonly ILog log;

        public log4net_logger(ILog log)
        {
            this.log = log;
        }

        public void informational(string formattedString, params object[] arguments)
        {
            log.InfoFormat(formattedString, arguments);
        }

        public void debug(string formattedString, params object[] arguments)
        {
            log.DebugFormat(formattedString, arguments);
        }

        public void error(Exception e)
        {
            log.Error(e.ToString());
        }
    }
}