using System.Collections.Generic;
using MyMoney.Infrastructure.Logging;

namespace MyMoney.Domain.Core
{
    public interface IRepository : ILoggable
    {
        IEnumerable<T> all<T>() where T : IEntity;
        void save<T>(T item) where T : IEntity;
    }
}