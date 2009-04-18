using System;
using System.Collections.Generic;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.Infrastructure.transactions2
{
    public interface IDatabase
    {
        IEnumerable<T> fetch_all<T>() where T : IIdentifiable<Guid>;
        void apply(IStatement statement);
    }
}