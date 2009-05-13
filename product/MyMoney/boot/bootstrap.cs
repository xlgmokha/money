using System;
using MoMoney.Presentation.Views.Shell;

namespace MoMoney.boot
{
    public class Bootstrap : WindowsFormsApplication<ApplicationShell>
    {
        [STAThread]
        static void Main()
        {
            new Bootstrap().run();
        }
    }
}