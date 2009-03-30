using System.Threading;
using MoMoney.Infrastructure.Container;
using MoMoney.Utility.Core;

namespace MoMoney.Tasks.infrastructure.updating
{
    public interface IProcessQueryCommand<T> : IParameterizedCommand<ICallback<T>>
    {
    }

    public class ProcessQueryCommand<T> : IProcessQueryCommand<T>
    {
        readonly IQuery<T> query;
        readonly SynchronizationContext context;

        public ProcessQueryCommand(IQuery<T> query) : this(query, resolve.dependency_for<SynchronizationContext>())
        {
        }

        public ProcessQueryCommand(IQuery<T> query, SynchronizationContext context)
        {
            this.query = query;
            this.context = context;
        }

        public void run(ICallback<T> item)
        {
            var result = query.fetch();
            context.Post(x => item.run(result), null);
        }
    }
}