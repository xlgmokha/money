using System;

namespace MoMoney.Presentation.Views
{
    public delegate void ControlAction<T>(T input) where T : EventArgs;
}