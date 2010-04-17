using gorilla.commons.utility;

namespace presentation.windows.service.infrastructure
{
    public interface CommandBuilder
    {
        CommandBuilder<TData> prepare<TData>(TData data);
        Command build<TCommand>(string message) where TCommand : Command;
    }

    public interface CommandBuilder<T>
    {
        Command build<TCommand>(string message) where TCommand : Command<T>;
    }
}