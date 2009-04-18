using System;

namespace MoMoney.Presentation.Views.core
{
    public delegate void ControlAction<T>(T input) where T : EventArgs;
}