using System.Collections.Generic;
using MoMoney.Domain.Core;
using MoMoney.Infrastructure.Logging;

namespace MoMoney.DataAccess.core
{
    public interface IDatabaseGateway : ILoggable
    {
        IEnumerable<T> all<T>() where T : IEntity;
        void save<T>(T item) where T : IEntity;
    }
}