using System;
using System.ComponentModel;

namespace MoMoney.Service.Infrastructure.Threading
{
    public interface IWorkerThread : IDisposable
    {
        event DoWorkEventHandler DoWork;
        event EventHandler Disposed;
        void begin();
    }
}