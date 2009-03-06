using System;
using System.IO;
using log4net;
using log4net.Config;
using MoMoney.Infrastructure.Extensions;

namespace MoMoney.Infrastructure.Logging.Log4NetLogging
{
    public class log4net_log_factory : ILogFactory
    {
        public log4net_log_factory()
        {
            XmlConfigurator.Configure(PathToConfigFile());
        }

        public ILogger create_for(Type typeToCreateLoggerFor)
        {
            return new log4net_logger(LogManager.GetLogger(typeToCreateLoggerFor));
        }

        private FileInfo PathToConfigFile()
        {
            return new FileInfo(Path.Combine(this.startup_directory(), "log4net.config.xml"));
        }
    }
}