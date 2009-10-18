using System;
using Gorilla.Commons.Utility.Core;
using MoMoney.Service.Infrastructure.Threading;

namespace MoMoney.Presentation.Presenters
{
    public interface IProcessQueryCommand<T> : IParameterizedCommand<ICallback<T>>
    {
    }

    public class ProcessQueryCommand<T> : IProcessQueryCommand<T>
    {
        readonly IQuery<T> query;
        readonly ISynchronizationContextFactory factory;

        public ProcessQueryCommand(IQuery<T> query, ISynchronizationContextFactory factory)
        {
            this.query = query;
            this.factory = factory;
        }

        public void run(ICallback<T> callback)
        {
            var dto = query.fetch();
            factory.create().run(new ActionCommand((Action) (() => callback.run(dto))));
        }
    }
}