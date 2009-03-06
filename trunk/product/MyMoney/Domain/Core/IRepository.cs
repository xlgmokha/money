using System.Collections.Generic;
using MoMoney.Infrastructure.Logging;

namespace MoMoney.Domain.Core
{
    public interface IRepository : ILoggable
    {
        IEnumerable<T> all<T>() where T : IEntity;
        void save<T>(T item) where T : IEntity;
    }
}