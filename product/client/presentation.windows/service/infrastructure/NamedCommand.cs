using gorilla.commons.utility;

namespace presentation.windows.service.infrastructure
{
    public class NamedCommand<T> : Command where T : Command
    {
        readonly string message;
        readonly T command;

        public NamedCommand(string message, T command)
        {
            this.message = message;
            this.command = command;
        }

        public void run()
        {
            command.run();
        }

        public override string ToString()
        {
            return message;
        }
    }
}