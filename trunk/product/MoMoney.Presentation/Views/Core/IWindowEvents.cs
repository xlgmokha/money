using System;
using System.ComponentModel;

namespace Gorilla.Commons.Windows.Forms
{
    public interface IWindowEvents
    {
        ControlAction<EventArgs> on_activated { get; set; }
        ControlAction<EventArgs> on_deactivate { get; set; }
        ControlAction<EventArgs> on_closed { get; set; }
        ControlAction<CancelEventArgs> on_closing { get; set; }
    }
}