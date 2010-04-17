using System;
using gorilla.commons.utility;
using momoney.service.infrastructure.threading;

namespace MoMoney.Presentation.Presenters
{
    public interface IProcessQueryCommand<T> : Command<Callback<T>> {}

    public class ProcessQueryCommand<T> : IProcessQueryCommand<T>
    {
        readonly Query<T> query;
        readonly ISynchronizationContextFactory factory;

        public ProcessQueryCommand(Query<T> query, ISynchronizationContextFactory factory)
        {
            this.query = query;
            this.factory = factory;
        }

        public void run_against(Callback<T> callback)
        {
            var dto = query.fetch();
            factory.create().run_against(new AnonymousCommand((Action) (() => callback.run_against(dto))));
        }
    }
}