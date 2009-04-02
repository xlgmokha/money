using System.Collections.Generic;
using MoMoney.Domain.Core;

namespace MoMoney.Infrastructure.transactions2
{
    public interface IDatabase
    {
        IEnumerable<T> fetch_all<T>() where T : IEntity;
    }
}