using System;
using MyMoney.Infrastructure.Container;
using MyMoney.Infrastructure.Logging.ConsoleLogging;

namespace MyMoney.Infrastructure.Logging
{
    public static class Log
    {
        public static ILogger For<T>(T item_to_create_logger_for)
        {
            return For(typeof (T));
        }

        public static ILogger For(Type type_to_create_a_logger_for)
        {
            try
            {
                return resolve.dependency_for<ILogFactory>().create_for(type_to_create_a_logger_for);
            }
            catch
            {
                return new console_logger();
            }
        }
    }
}