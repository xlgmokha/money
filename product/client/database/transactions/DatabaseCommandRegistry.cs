using System;
using gorilla.commons.utility;

namespace momoney.database.transactions
{
    public interface DatabaseCommandRegistry
    {
        DatabaseCommand prepare_for_deletion<T>(T entity) where T : Identifiable<Guid>;
        DatabaseCommand prepare_for_flushing<T>(T entity) where T : Identifiable<Guid>;
    }
}