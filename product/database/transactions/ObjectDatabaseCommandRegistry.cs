using System;
using gorilla.commons.utility;

namespace momoney.database.transactions
{
    public class ObjectDatabaseCommandRegistry : DatabaseCommandRegistry
    {
        public DatabaseCommand prepare_for_deletion<T>(T entity) where T : Identifiable<Guid>
        {
            return new DeleteFromDatabase<T>(entity);
        }

        public DatabaseCommand prepare_for_flushing<T>(T entity) where T : Identifiable<Guid>
        {
            return new SaveOrUpdateFromDatabase<T>(entity);
        }
    }
}