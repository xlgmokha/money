using System;
using MoMoney.boot;
using MoMoney.Presentation.Winforms.Views;

namespace MoMoney
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