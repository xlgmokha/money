using System;
using MyMoney.Infrastructure.Container;
using MyMoney.Utility.Core;

namespace MyMoney.Infrastructure.Threading
{
    public interface IBackgroundThreadFactory
    {
        IBackgroundThread create_for<CommandToExecute>() where CommandToExecute : IDisposableCommand;
        IBackgroundThread create_for(Action action);
    }

    public class background_thread_factory : IBackgroundThreadFactory
    {
        private readonly IDependencyRegistry registry;

        public background_thread_factory(IDependencyRegistry registry)
        {
            this.registry = registry;
        }

        public IBackgroundThread create_for<CommandToExecute>() where CommandToExecute : IDisposableCommand
        {
            return new background_thread(registry.find_an_implementation_of<CommandToExecute>());
        }

        public IBackgroundThread create_for(Action action)
        {
            return new background_thread(new command(action));
        }
    }
}