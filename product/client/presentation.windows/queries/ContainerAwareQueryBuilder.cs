using System;
using Gorilla.Commons.Infrastructure.Container;
using momoney.service.infrastructure.transactions;

namespace presentation.windows.queries
{
    public class ContainerAwareQueryBuilder : QueryBuilder
    {
        IUnitOfWorkFactory factory;

        public ContainerAwareQueryBuilder(IUnitOfWorkFactory factory)
        {
            this.factory = factory;
        }

        public void build<Query>(Action<Query> action) where Query : class
        {
            using (var unit_of_work = factory.create())
            {
                action(Resolve.the<Query>());
                unit_of_work.commit();
            }
        }
    }
}