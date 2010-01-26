using System;
using gorilla.commons.utility;
using momoney.service.infrastructure.threading;

namespace MoMoney.Presentation.Presenters
{
    public interface IProcessQueryCommand<T> : ParameterizedCommand<Callback<T>> {}

    public class ProcessQueryCommand<T> : IProcessQueryCommand<T>
    {
        readonly Query<T> query;
        readonly ISynchronizationContextFactory factory;

        public ProcessQueryCommand(Query<T> query, ISynchronizationContextFactory factory)
        {
            this.query = query;
            this.factory = factory;
        }

        public void run(Callback<T> callback)
        {
            var dto = query.fetch();
            factory.create().run(new AnonymousCommand((Action) (() => callback.run(dto))));
        }
    }
}