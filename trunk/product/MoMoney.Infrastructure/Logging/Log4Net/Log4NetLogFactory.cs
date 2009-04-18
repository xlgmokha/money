using System;
using System.IO;
using Gorilla.Commons.Infrastructure.Logging;
using log4net;
using log4net.Config;
using MoMoney.Infrastructure.Extensions;

namespace MoMoney.Infrastructure.Logging.Log4Net
{
    public class Log4NetLogFactory : ILogFactory
    {
        public Log4NetLogFactory()
        {
            XmlConfigurator.Configure(PathToConfigFile());
        }

        public ILogger create_for(Type type_to_create_logger_for)
        {
            return new Log4NetLogger(LogManager.GetLogger(type_to_create_logger_for));
        }

        private FileInfo PathToConfigFile()
        {
            return new FileInfo(Path.Combine(this.startup_directory(), "log4net.config.xml"));
        }
    }
}