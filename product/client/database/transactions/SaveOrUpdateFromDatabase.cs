using System;
using gorilla.commons.utility;

namespace momoney.database.transactions
{
    public class SaveOrUpdateFromDatabase<T> : DatabaseCommand where T : Identifiable<Guid>
    {
        readonly T entity;

        public SaveOrUpdateFromDatabase(T entity)
        {
            this.entity = entity;
        }

        public void run_against(DatabaseConnection connection)
        {
            connection.store(entity);
        }
    }
}