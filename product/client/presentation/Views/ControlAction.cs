using System;

namespace momoney.presentation.views
{
    public delegate void ControlAction<T>(T input) where T : EventArgs;
}