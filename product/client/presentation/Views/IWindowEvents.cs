using System;
using System.ComponentModel;
using momoney.presentation.views;

namespace MoMoney.Presentation.Views
{
    public interface IWindowEvents
    {
        ControlAction<EventArgs> activated { get; set; }
        ControlAction<EventArgs> deactivated { get; set; }
        ControlAction<EventArgs> closed { get; set; }
        ControlAction<CancelEventArgs> closing { get; set; }
    }
}