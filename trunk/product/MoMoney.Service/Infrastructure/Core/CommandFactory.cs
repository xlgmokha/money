using Gorilla.Commons.Utility.Core;

namespace MoMoney.Tasks.infrastructure.core
{
    public interface ICommandFactory
    {
        ICommand create_for<T>(ICallback<T> item, IQuery<T> query);
    }

    public class CommandFactory : ICommandFactory
    {
        public ICommand create_for<T>(ICallback<T> item, IQuery<T> query)
        {
            return new RunQueryCommand<T>(item, new ProcessQueryCommand<T>(query));
        }
    }
}