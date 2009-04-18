using System;

namespace MoMoney.Infrastructure.Logging
{
    public interface ILogFactory
    {
        ILogger create_for(Type typeToCreateLoggerFor);
    }
}