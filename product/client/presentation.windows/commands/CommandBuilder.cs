using gorilla.commons.utility;

namespace presentation.windows.commands
{
    public interface CommandBuilder
    {
        ParameterizedCommandBuilder<TData> prepare<TData>(TData data);
        Command build<TCommand>(string message) where TCommand : Command;
    }

}