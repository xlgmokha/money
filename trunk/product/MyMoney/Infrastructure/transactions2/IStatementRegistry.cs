namespace MoMoney.Infrastructure.transactions2
{
    public interface IStatementRegistry
    {
        IStatement prepare_insert_statement_for<T>(T entity);
        IStatement prepare_update_statement_for<T>(T entity);
        IStatement prepare_delete_statement_for<T>(T entity);
    }
}