using System;

namespace MyMoney.Infrastructure.Logging
{
    public interface ILogger
    {
        void informational(string formattedString, params object[] arguments);
        void debug(string formattedString, params object[] arguments);
        void error(Exception e);
    }
}