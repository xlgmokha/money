using System;
using System.Collections.Generic;
using gorilla.commons.utility;

namespace momoney.database.transactions
{
    public interface IDatabase
    {
        IEnumerable<T> fetch_all<T>() where T : Identifiable<Guid>;
        void apply(DatabaseCommand command);
    }
}