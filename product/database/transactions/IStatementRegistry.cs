using System;
using gorilla.commons.utility;

namespace momoney.database.transactions
{
    public interface IStatementRegistry
    {
        IStatement prepare_delete_statement_for<T>(T entity) where T : Identifiable<Guid>;
        IStatement prepare_command_for<T>(T entity) where T : Identifiable<Guid>;
    }
}