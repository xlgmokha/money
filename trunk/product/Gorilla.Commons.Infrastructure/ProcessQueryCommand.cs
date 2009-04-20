using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Infrastructure
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

        public void run(ICallback<T> callback)
        {
            callback.run(query.fetch());
        }
    }
}