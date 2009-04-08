using System;
using MoMoney.Presentation.Views.Shell;

namespace MoMoney.boot
{
    public class bootstrap : WindowsFormsApplication<ApplicationShell>
    {
        [STAThread]
        static void Main()
        {
            new bootstrap().run();
        }
    }
}