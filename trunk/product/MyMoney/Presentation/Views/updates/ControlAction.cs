using System;

namespace MoMoney.Presentation.Views.updates
{
    public delegate void ControlAction<T>(T input) where T : EventArgs;
}