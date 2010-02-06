using gorilla.commons.utility;

namespace presentation.windows.commands
{
    public interface ParameterizedCommandBuilder<T>
    {
        Command build<TCommand>(string message) where TCommand : ArgCommand<T>;
    }
}