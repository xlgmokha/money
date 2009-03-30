using MoMoney.Domain.Core;

namespace MoMoney.Infrastructure.transactions2
{
    public interface ISession
    {
        void save<T>(T entity) where T : IEntity;
    }

    public class Session : ISession
    {
        IIdentityMapFactory factory;

        public Session(IIdentityMapFactory factory)
        {
            this.factory = factory;
        }

        public void save<T>(T entity) where T : IEntity
        {
            factory.create_for<T>().add(entity.Id, entity);
        }
    }
}