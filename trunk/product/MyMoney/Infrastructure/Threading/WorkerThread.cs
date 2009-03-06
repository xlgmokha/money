using System;
using System.ComponentModel;

namespace MoMoney.Infrastructure.Threading
{
    public interface IWorkerThread : IDisposable
    {
        event DoWorkEventHandler DoWork;
        event EventHandler Disposed;
        void Begin();
    }

    public class WorkerThread : Component, IWorkerThread
    {
        private static readonly object do_work_key = new object();
        private bool is_running;
        private readonly Action background_thread;

        public WorkerThread()
        {
            background_thread = worker_thread_start;
        }

        public event DoWorkEventHandler DoWork
        {
            add { Events.AddHandler(do_work_key, value); }
            remove { Events.RemoveHandler(do_work_key, value); }
        }

        public void Begin()
        {
            if (is_running) {
                throw new InvalidOperationException("Worker Thread Is Already Running");
            }
            is_running = true;
            background_thread.BeginInvoke(null, null);
        }

        private void worker_thread_start()
        {
            try {
                var handler = (DoWorkEventHandler) Events[do_work_key];
                if (handler != null) {
                    handler(this, new DoWorkEventArgs(null));
                }
            }
            catch (Exception) {}
        }
    }
}