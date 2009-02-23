using System;

namespace MyMoney.Infrastructure.Logging
{
    public interface ILogFactory
    {
        ILogger create_for(Type typeToCreateLoggerFor);
    }
}