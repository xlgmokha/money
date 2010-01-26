using System;
using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.Utility;

namespace momoney.service.infrastructure.threading
{
    public interface IBackgroundThreadFactory
    {
        IBackgroundThread create_for<CommandToExecute>() where CommandToExecute : DisposableCommand;
        IBackgroundThread create_for(Action action);
    }

    public class BackgroundThreadFactory : IBackgroundThreadFactory
    {
        readonly DependencyRegistry registry;

        public BackgroundThreadFactory(DependencyRegistry registry)
        {
            this.registry = registry;
        }

        public IBackgroundThread create_for<CommandToExecute>() where CommandToExecute : DisposableCommand
        {
            return new BackgroundThread(registry.get_a<CommandToExecute>());
        }

        public IBackgroundThread create_for(Action action)
        {
            return new BackgroundThread(new AnonymousDisposableCommand(action));
        }

        class AnonymousDisposableCommand : DisposableCommand
        {
            readonly Action action;

            public AnonymousDisposableCommand(Action action)
            {
                this.action = action;
            }

            public void run()
            {
                action();
            }

            public void Dispose() {}
        }
    }
}