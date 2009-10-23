using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.utility;
using MoMoney.Service.Infrastructure.Threading;

namespace MoMoney.Presentation.Presenters
{
    public interface ICommandPump
    {
        ICommandPump run<Command>() where Command : gorilla.commons.utility.Command;
        ICommandPump run<Command, T>(T input) where Command : ParameterizedCommand<T>;
        ICommandPump run<Output, Query>(Callback<Output> item) where Query : Query<Output>;
    }

    public class CommandPump : ICommandPump
    {
        readonly CommandProcessor processor;
        readonly DependencyRegistry registry;
        readonly ICommandFactory factory;

        public CommandPump(CommandProcessor processor, DependencyRegistry registry, ICommandFactory factory)
        {
            this.processor = processor;
            this.factory = factory;
            this.registry = registry;
        }

        public ICommandPump run<Command>() where Command : gorilla.commons.utility.Command
        {
            return run(registry.get_a<Command>());
        }

        public ICommandPump run<Command>(Command command) where Command : gorilla.commons.utility.Command
        {
            processor.add(command);
            return this;
        }

        public ICommandPump run<Command, T>(T input) where Command : ParameterizedCommand<T>
        {
            processor.add(() => registry.get_a<Command>().run(input));
            return this;
        }

        public ICommandPump run<T>(Callback<T> item, Query<T> query)
        {
            return run(factory.create_for(item, query));
        }

        public ICommandPump run<Output, Query>(Callback<Output> item) where Query : Query<Output>
        {
            return run(item, registry.get_a<Query>());
        }
    }
}