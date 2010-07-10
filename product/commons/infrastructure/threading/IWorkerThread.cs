using System;
using System.ComponentModel;

namespace gorilla.commons.infrastructure.threading
{
    public interface IWorkerThread : IDisposable
    {
        event DoWorkEventHandler DoWork;
        event EventHandler Disposed;
        void begin();
    }
}