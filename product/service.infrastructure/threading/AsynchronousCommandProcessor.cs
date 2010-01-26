using System;
using System.Collections.Generic;
using System.Threading;
using gorilla.commons.utility;

namespace MoMoney.Service.Infrastructure.Threading
{
    public class AsynchronousCommandProcessor : CommandProcessor
    {
        readonly Queue<Command> queued_commands;
        readonly EventWaitHandle manual_reset;
        readonly IList<Thread> worker_threads;
        bool keep_working;

        public AsynchronousCommandProcessor()
        {
            queued_commands = new Queue<Command>();
            worker_threads = new List<Thread>();
            manual_reset = new ManualResetEvent(false);
        }

        public void add(Action command)
        {
            add(new AnonymousCommand(command));
        }

        public void add(Command command_to_process)
        {
            lock (queued_commands)
            {
                if (queued_commands.Contains(command_to_process)) return;
                queued_commands.Enqueue(command_to_process);
                reset_thread();
            }
        }

        public void run()
        {
            reset_thread();
            keep_working = true;
            var worker_thread = new Thread(run_commands);
            worker_thread.SetApartmentState(ApartmentState.STA);
            worker_threads.Add(worker_thread);
            worker_thread.Start();
        }

        public void stop()
        {
            keep_working = false;
            manual_reset.Set();
            //manual_reset.Close();
        }

        [STAThread]
        void run_commands()
        {
            while (keep_working)
            {
                manual_reset.WaitOne();
                run_next_command();
            }
        }

        void run_next_command()
        {
            Command command;
            lock (queued_commands)
            {
                if (queued_commands.Count == 0)
                {
                    manual_reset.Reset();
                    return;
                }
                command = queued_commands.Dequeue();
            }
            command.run();
            reset_thread();
        }

        void reset_thread()
        {
            lock (queued_commands)
            {
                if (queued_commands.Count > 0) manual_reset.Set();
                else manual_reset.Reset();
            }
        }
    }
}