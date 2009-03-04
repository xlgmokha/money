using MyMoney.Utility.Core;

namespace MyMoney.Infrastructure.Threading
{
    public interface IBackgroundThread : IDisposableCommand
    {
    }

    public class BackgroundThread : IBackgroundThread
    {
        readonly IWorkerThread worker_thread;

        public BackgroundThread(IDisposableCommand command_to_execute) : this(command_to_execute, new WorkerThread())
        {
        }

        public BackgroundThread(IDisposableCommand command_to_execute, IWorkerThread worker_thread)
        {
            this.worker_thread = worker_thread;
            worker_thread.DoWork += ((sender, e) => command_to_execute.run());
            worker_thread.Disposed += ((sender, e) => command_to_execute.Dispose());
        }

        public void Dispose()
        {
            worker_thread.Dispose();
        }

        public void run()
        {
            worker_thread.Begin();
        }
    }
}