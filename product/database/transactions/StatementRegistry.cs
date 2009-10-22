using System;
using gorilla.commons.utility;

namespace momoney.database.transactions
{
    public class StatementRegistry : IStatementRegistry
    {
        public IStatement prepare_delete_statement_for<T>(T entity) where T : Identifiable<Guid>
        {
            return new DeletionStatement<T>(entity);
        }

        public IStatement prepare_command_for<T>(T entity) where T : Identifiable<Guid>
        {
            return new SaveOrUpdateStatement<T>(entity);
        }
    }

    public class SaveOrUpdateStatement<T> : IStatement where T : Identifiable<Guid>
    {
        readonly T entity;

        public SaveOrUpdateStatement(T entity)
        {
            this.entity = entity;
        }

        public void prepare(IDatabaseConnection connection)
        {
            connection.store(entity);
        }
    }

    public class DeletionStatement<T> : IStatement
    {
        readonly T entity;

        public DeletionStatement(T entity)
        {
            this.entity = entity;
        }

        public void prepare(IDatabaseConnection connection)
        {
            connection.delete(entity);
        }
    }
}