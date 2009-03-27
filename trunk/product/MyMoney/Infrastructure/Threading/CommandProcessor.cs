using System.Collections.Generic;
using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.Threading
{
    public class CommandProcessor : ICommandProcessor
    {
        readonly Queue<ICommand> queued_commands;

        public CommandProcessor()
        {
            queued_commands = new Queue<ICommand>();
        }

        public void add(ICommand command_to_process)
        {
            queued_commands.Enqueue(command_to_process);
        }

        public void run()
        {
            while (queued_commands.Count > 0)
            {
                queued_commands.Dequeue().run();
            }
        }
    }
}