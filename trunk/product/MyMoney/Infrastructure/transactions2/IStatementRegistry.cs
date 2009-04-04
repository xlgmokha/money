using System;

namespace MoMoney.Infrastructure.transactions2
{
    public interface IStatementRegistry
    {
        [Obsolete]
        IStatement prepare_insert_statement_for<T>(T entity);

        [Obsolete]
        IStatement prepare_update_statement_for<T>(T entity);

        IStatement prepare_delete_statement_for<T>(T entity);
        IStatement prepare_command_for<T>(T entity);
    }
}