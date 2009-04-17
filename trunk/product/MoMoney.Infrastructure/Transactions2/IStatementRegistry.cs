using MoMoney.Domain.Core;

namespace MoMoney.Infrastructure.transactions2
{
    public interface IStatementRegistry
    {
        IStatement prepare_delete_statement_for<T>(T entity) where T : IEntity;
        IStatement prepare_command_for<T>(T entity) where T : IEntity;
    }
}