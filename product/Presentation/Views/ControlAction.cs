using System;

namespace MoMoney.Presentation.Views.Core
{
    public delegate void ControlAction<T>(T input) where T : EventArgs;
}