using System;
using MyMoney.Infrastructure.Logging;

namespace MyMoney.Infrastructure.Extensions
{
    public static class logging_extensions
    {
        public static ILogger log<T>(this T item_to_log)
        {
            return Log.For(item_to_log);
        }

        public static void add_to_log(this Exception error_to_log)
        {
            Log.For(error_to_log).error(error_to_log);
        }
    }
}