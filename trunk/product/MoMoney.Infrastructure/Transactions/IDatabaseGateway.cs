using System.Collections.Generic;
using MoMoney.Domain.Core;

namespace MoMoney.DataAccess.core
{
    public interface IDatabaseGateway
    {
        IEnumerable<T> all<T>() where T : IEntity;
        void save<T>(T item) where T : IEntity;
    }
}