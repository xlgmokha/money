using System;
using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.utility;
using momoney.database.transactions;
using MoMoney.Service.Infrastructure.Eventing;
using momoney.service.infrastructure.transactions;
using ISession = NHibernate.ISession;
using ISessionFactory = NHibernate.ISessionFactory;
using ITransaction = NHibernate.ITransaction;

namespace presentation.windows.commands
{
    public class ContainerAwareParameterizedCommandBuilder<T> : ParameterizedCommandBuilder<T>, Command
    {
        readonly T data;
        Action action;
        EventAggregator event_broker;
        IUnitOfWorkFactory factory;

        public ContainerAwareParameterizedCommandBuilder(T data, EventAggregator event_broker, IUnitOfWorkFactory factory)
        {
            this.data = data;
            this.factory = factory;
            this.event_broker = event_broker;
        }

        public Command build<TCommand>(string message) where TCommand : ArgCommand<T>
        {
            action = () =>
            {
                event_broker.publish(new UpdateOnLongRunningProcess
                                     {
                                         message = message,
                                         percent_complete = 0,
                                     });
                //need to resolve the command on the background thread in order to resolve the thread specific session.
                Resolve.the<TCommand>().run_against(data);
                event_broker.publish(new UpdateOnLongRunningProcess
                                     {
                                         percent_complete = 100,
                                     });
            };

            return this;
        }

        public void run()
        {
            using (var unit_of_work = factory.create())
            {
                action();
                unit_of_work.commit();
            }
        }
    }

    public class NHibernateUnitOfWorkFactory : IUnitOfWorkFactory
    {
        readonly ISessionFactory factory;
        readonly IContext context;

        public NHibernateUnitOfWorkFactory(ISessionFactory factory, IContext context)
        {
            this.factory = factory;
            this.context = context;
        }

        public IUnitOfWork create()
        {
            var open_session = factory.OpenSession();
            context.add(new TypedKey<ISession>(), open_session);
            return new NHibernateUnitOfWork(open_session, context);
        }
    }

    public class NHibernateUnitOfWork : IUnitOfWork
    {
        readonly ISession session;
        readonly IContext context;
        ITransaction transaction;

        public NHibernateUnitOfWork(ISession session, IContext context)
        {
            this.session = session;
            this.context = context;
            transaction = session.BeginTransaction();
        }

        public void Dispose()
        {
            if (!transaction.WasCommitted && !transaction.WasRolledBack)
            {
                transaction.Rollback();
            }
            session.Dispose();
            context.remove(new TypedKey<ISession>());
        }

        public void commit()
        {
            if (is_dirty()) transaction.Commit();
        }

        public bool is_dirty()
        {
            return session.IsDirty();
        }
    }
}