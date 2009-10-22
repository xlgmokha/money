using gorilla.commons.utility;
using momoney.presentation.presenters;
using momoney.service.infrastructure.threading;

namespace MoMoney.Presentation.Presenters
{
    public interface ICommandFactory
    {
        Command create_for<T>(Callback<T> item, Query<T> query);
    }

    public class CommandFactory : ICommandFactory
    {
        readonly ISynchronizationContextFactory factory;

        public CommandFactory(ISynchronizationContextFactory factory)
        {
            this.factory = factory;
        }

        public Command create_for<T>(Callback<T> item, Query<T> query)
        {
            return new RunQueryCommand<T>(item, new ProcessQueryCommand<T>(query, factory));
        }
    }
}