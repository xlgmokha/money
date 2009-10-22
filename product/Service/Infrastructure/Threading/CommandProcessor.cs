using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using gorilla.commons.utility;

namespace MoMoney.Service.Infrastructure.Threading
{
    public class CommandProcessor : ICommandProcessor
    {
        readonly Queue<Command> queued_commands;

        public CommandProcessor()
        {
            queued_commands = new Queue<Command>();
        }

        public void add(Expression<Action> action_to_process)
        {
            add(new AnonymousCommand(action_to_process));
        }

        public void add(Command command_to_process)
        {
            queued_commands.Enqueue(command_to_process);
        }

        public void run()
        {
            while (queued_commands.Count > 0) queued_commands.Dequeue().run();
        }

        public void stop()
        {
            queued_commands.Clear();
        }
    }
}