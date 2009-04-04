using System;

namespace MoMoney.Infrastructure.transactions2
{
    public class StatementRegistry : IStatementRegistry
    {
        public IStatement prepare_delete_statement_for<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public IStatement prepare_command_for<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}