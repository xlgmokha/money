using System;
using System.Windows.Forms;
using MyMoney.Infrastructure.Extensions;
using MyMoney.Utility.Core;
using MyMoney.Utility.Extensions;

namespace MyMoney.windows.ui
{
    internal class global_error_handling : ICommand
    {
        public void run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += (sender, e) => e.Exception.add_to_log();
            AppDomain.CurrentDomain.UnhandledException += ((sender, e) => sender.log().error(e.ExceptionObject.downcast_to<Exception>()));
        }
    }
}