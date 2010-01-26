using System;
using System.Windows.Forms;

namespace MoMoney.Presentation.Winforms.Helpers
{
    public class ControlAdapter : Control
    {
        readonly IDisposable item;

        public ControlAdapter(IDisposable item)
        {
            this.item = item;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) item.Dispose();
            base.Dispose(disposing);
        }
    }
}