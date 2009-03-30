using System;
using MoMoney.Infrastructure.caching;

namespace MoMoney.Infrastructure.transactions2
{
    public interface IIdentityMapFactory
    {
        IIdentityMap<Guid, T> create_for<T>();
    }
}