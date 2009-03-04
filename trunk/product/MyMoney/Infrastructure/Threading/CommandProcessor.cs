using System.Collections.Generic;
using MyMoney.Utility.Core;

namespace MyMoney.Infrastructure.Threading
{
    public interface ICommandProcessor : ICommand
    {
        void add(ICommand command_to_add_to_queue);
    }

    public class CommandProcessor : ICommandProcessor
    {
        private readonly Queue<ICommand> queued_commands;

        public CommandProcessor()
        {
            queued_commands = new Queue<ICommand>();
        }

        public void add(ICommand command_to_add_to_queue)
        {
            queued_commands.Enqueue(command_to_add_to_queue);
        }

        public void run()
        {
            while (queued_commands.Count > 0) {
                queued_commands.Dequeue().run();
            }
        }
    }
}