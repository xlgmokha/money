using System;
using System.ComponentModel;

namespace momoney.service.infrastructure.threading
{
    public interface IWorkerThread : IDisposable
    {
        event DoWorkEventHandler DoWork;
        event EventHandler Disposed;
        void begin();
    }
}