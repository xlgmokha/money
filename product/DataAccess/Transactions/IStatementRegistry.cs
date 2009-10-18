using System;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.DataAccess.Transactions
{
    public interface IStatementRegistry
    {
        IStatement prepare_delete_statement_for<T>(T entity) where T : IIdentifiable<Guid>;
        IStatement prepare_command_for<T>(T entity) where T : IIdentifiable<Guid>;
    }
}