using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.Threading;
using MoMoney.Utility.Core;

namespace MoMoney.Tasks.infrastructure.core
{
    public interface ICommandPump
    {
        void run<Command>() where Command : ICommand;
        void run<Command>(Command command) where Command : ICommand;
        void run<Command, T>(T input) where Command : IParameterizedCommand<T>;
        void run<T>(ICallback<T> item, IQuery<T> query);
        void run<Output, Query>(ICallback<Output> item) where Query : IQuery<Output>;
    }

    public class CommandPump : ICommandPump
    {
        readonly ICommandProcessor processor;
        readonly IDependencyRegistry registry;
        readonly ICommandFactory factory;

        public CommandPump(ICommandProcessor processor, IDependencyRegistry registry, ICommandFactory factory)
        {
            this.processor = processor;
            this.factory = factory;
            this.registry = registry;
        }

        public void run<Command>() where Command : ICommand
        {
            run(registry.get_a<Command>());
        }

        public void run<Command>(Command command) where Command : ICommand
        {
            processor.add(command);
        }

        public void run<Command, T>(T input) where Command : IParameterizedCommand<T>
        {
            processor.add(() => registry.get_a<Command>().run(input));
        }

        public void run<T>(ICallback<T> item, IQuery<T> query)
        {
            run(factory.create_for(item, query));
        }

        public void run<Output, Query>(ICallback<Output> item) where Query : IQuery<Output>
        {
            run(item, registry.get_a<Query>());
        }
    }
}