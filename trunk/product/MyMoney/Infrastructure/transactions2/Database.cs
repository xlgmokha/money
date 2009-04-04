using System;
using System.Collections.Generic;
using MoMoney.Domain.Core;

namespace MoMoney.Infrastructure.transactions2
{
    public class Database : IDatabase
    {
        public IEnumerable<T> fetch_all<T>() where T : IEntity
        {
            throw new NotImplementedException();
        }

        public void apply(IStatement statement)
        {
            throw new NotImplementedException();
        }
    }
}