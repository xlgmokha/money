using System;
using System.IO;
using log4net;
using log4net.Config;
using MoMoney.Infrastructure.Extensions;

namespace MoMoney.Infrastructure.Logging.Log4NetLogging
{
    public class Log4NetLogFactory : ILogFactory
    {
        public Log4NetLogFactory()
        {
            XmlConfigurator.Configure(PathToConfigFile());
        }

        public ILogger create_for(Type typeToCreateLoggerFor)
        {
            return new Log4NetLogger(LogManager.GetLogger(typeToCreateLoggerFor));
        }

        private FileInfo PathToConfigFile()
        {
            return new FileInfo(Path.Combine(this.startup_directory(), "log4net.config.xml"));
        }
    }
}