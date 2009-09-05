using System;

namespace Gorilla.Commons.Windows.Forms
{
    public delegate void ControlAction<T>(T input) where T : EventArgs;
}