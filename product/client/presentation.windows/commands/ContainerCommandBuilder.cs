using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.utility;

namespace presentation.windows.commands
{
    public class ContainerCommandBuilder : CommandBuilder
    {
        public ParameterizedCommandBuilder<T> prepare<T>(T data)
        {
            return new ContainerAwareParameterizedCommandBuilder<T>(data);
        }

        public Command build<T>(string message) where T : Command
        {
            return new NamedCommand<T>(message, Resolve.the<T>());
        }
    }
}