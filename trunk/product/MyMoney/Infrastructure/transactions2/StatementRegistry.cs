using Db4objects.Db4o;
using MoMoney.Domain.Core;
using MoMoney.Utility.Extensions;

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

        public void prepare(IObjectContainer connection)
        {
            var query = connection.Query<T>(x => x.id.Equals(entity.id));
            query.each(x => connection.Delete(x));
            connection.Store(entity);
        }
    }

    public class DeletionStatement<T> : IStatement
    {
        readonly T entity;

        public DeletionStatement(T entity)
        {
            this.entity = entity;
        }

        public void prepare(IObjectContainer connection)
        {
            connection.Delete(entity);
        }
    }
}