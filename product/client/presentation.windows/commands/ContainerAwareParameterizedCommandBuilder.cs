using System;
using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.utility;

namespace presentation.windows.commands
{
    public class ContainerAwareParameterizedCommandBuilder<T> : ParameterizedCommandBuilder<T>, Command
    {
        readonly T data;
        Action action;
        string message;
        public ContainerAwareParameterizedCommandBuilder(T data)
        {
            this.data = data;
        }

        public Command build<TCommand>(string message) where TCommand : ArgCommand<T>
        {
            this.message = message;
            action = () =>
            {
                Resolve.the<TCommand>().run_against(data);
            };

            return this;
        }

        public void run()
        {
            action();
        }

        public override string ToString()
        {
            return message;
        }
    }
}