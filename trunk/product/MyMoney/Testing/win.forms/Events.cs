using System;
using System.Windows.Forms;

namespace MyMoney.Testing.win.forms
{
    public class Events
    {
        public interface ControlEvents : IEventTarget
        {
            void OnEnter(EventArgs args);
            void OnKeyPress(KeyPressEventArgs args);
        }

        public interface FormEvents : ControlEvents
        {
            void OnActivated(EventArgs e);
            void OnDeactivate(EventArgs e);
        }
    }
}