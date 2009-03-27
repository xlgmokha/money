using System.Collections.Generic;
using System.Threading;
using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.Threading
{
    public class AsynchronousCommandProcessor : ICommandProcessor
    {
        readonly Queue<ICommand> queued_commands;
        readonly EventWaitHandle manual_reset;

        public AsynchronousCommandProcessor()
        {
            queued_commands = new Queue<ICommand>();
            manual_reset = new ManualResetEvent(false);
        }

        public void add(ICommand command_to_add_to_queue)
        {
            lock (queued_commands)
            {
                queued_commands.Enqueue(command_to_add_to_queue);
                reset_thread();
            }
        }

        public void run()
        {
            reset_thread();
            new Thread(execute_commands).Start();
        }

        void execute_commands()
        {
            manual_reset.WaitOne();
            next_command().run();
            reset_thread();
        }

        ICommand next_command()
        {
            lock (queued_commands)
            {
                if (queued_commands.Count == 0)
                {
                    manual_reset.Reset();
                    return new EmptyCommand();
                }
                return queued_commands.Dequeue();
            }
        }

        void reset_thread()
        {
            lock (queued_commands)
            {
                if (queued_commands.Count > 0)
                {
                    manual_reset.Set();
                }
                else
                {
                    manual_reset.Reset();
                }
            }
        }
    }
}