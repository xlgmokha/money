using MoMoney.Domain.Core;
using MoMoney.Infrastructure.Extensions;

namespace MoMoney.Infrastructure.transactions2
{
    public class StatementRegistry : IStatementRegistry
    {
        public IStatement prepare_delete_statement_for<T>(T entity) where T : IEntity
        {
            return new DeletionStatement<T>(entity);
        }

        public IStatement prepare_command_for<T>(T entity) where T : IEntity
        {
            return new SaveOrUpdateStatement<T>(entity);
        }
    }

    public class SaveOrUpdateStatement<T> : IStatement where T : IEntity
    {
        readonly T entity;

        public SaveOrUpdateStatement(T entity)
        {
            this.entity = entity;
        }

        public void prepare(IDatabaseConnection connection)
        {
            connection.store(entity);
            this.log().debug("saving: {0}", entity);
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