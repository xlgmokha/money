using System;
using System.Windows.Forms;

namespace MoMoney.Presentation.Views.helpers
{
    public class SuspendLayout : IDisposable
    {
        readonly Control control;

        public SuspendLayout(Control control)
        {
            this.control = control;
            control.SuspendLayout();
        }

        public void Dispose()
        {
            control.ResumeLayout();
        }
    }
}