using System.Collections.Generic;
using Db4objects.Db4o;
using MyMoney.Domain.Core;
using MyMoney.Infrastructure.Extensions;
using MyMoney.Utility.Extensions;

namespace MyMoney.DataAccess.db40
{
    public class db4o_repository : IRepository
    {
        readonly ISessionFactory factory;

        public db4o_repository(ISessionFactory factory)
        {
            this.factory = factory;
        }

        public IEnumerable<T> all<T>() where T : IEntity
        {
            open_session_with_database().Query<T>().each(x => this.log().debug("found item: {0}", x));
            return open_session_with_database().Query<T>();
            //return open_session_with_database().Cast<T>();
        }

        public void save<T>(T item) where T : IEntity
        {
            this.log().debug("saving: {0}, {1}", item.ToString(), item.Id);
            open_session_with_database().Store(item);
            open_session_with_database().Commit();
        }

        IObjectContainer open_session_with_database()
        {
            return factory.create();
        }
    }
}