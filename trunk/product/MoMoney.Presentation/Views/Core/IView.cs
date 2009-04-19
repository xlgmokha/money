using System;
using System.ComponentModel;

namespace Gorilla.Commons.Windows.Forms
{
    public interface IView : IWindowEvents, ISynchronizeInvoke, IDisposable
    {
    }
}