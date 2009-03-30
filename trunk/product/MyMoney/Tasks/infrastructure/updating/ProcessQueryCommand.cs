using MoMoney.Utility.Core;

namespace MoMoney.Tasks.infrastructure.updating
{
    public interface IProcessQueryCommand<T> : IParameterizedCommand<ICallback<T>>
    {
    }

    public class ProcessQueryCommand<T> : IProcessQueryCommand<T>
    {
        readonly IQuery<T> query;

        public ProcessQueryCommand(IQuery<T> query)
        {
            this.query = query;
        }

        public void run(ICallback<T> item)
        {
            item.run(query.fetch());
        }
    }
}