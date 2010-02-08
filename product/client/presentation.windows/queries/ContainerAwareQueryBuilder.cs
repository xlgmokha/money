using Castle.DynamicProxy;
using momoney.service.infrastructure.transactions;
using presentation.windows.infrastructure;

namespace presentation.windows.queries
{
    public class ContainerAwareQueryBuilder : QueryBuilder
    {
        IUnitOfWorkFactory factory;
        ProxyGenerator generator;
        AnonymousInterceptor anonymous_interceptor;

        public ContainerAwareQueryBuilder(IUnitOfWorkFactory factory)
        {
            this.factory = factory;
            generator = new ProxyGenerator();
            anonymous_interceptor = new AnonymousInterceptor(x =>
            {
                using (var unit_of_work = factory.create())
                {
                    x.Proceed();
                    unit_of_work.commit();
                }
            });
        }

        public Query build<Query>() where Query : class
        {
            return generator.CreateClassProxy<Query>(anonymous_interceptor);

            //var proxy_builder = new CastleDynamicProxyBuilder<Query>();
            //proxy_builder.add_interceptor(anonymous_interceptor);
            //return proxy_builder.create_proxy_for(Resolve.the<Query>());
        }
    }
}