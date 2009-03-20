using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.eventing;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Presentation.Model.messages;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.boot
{
    internal class global_error_handling : ICommand
    {
        public void run()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += (sender, e) => handle_error(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += ((sender, e) => handle_error(e.ExceptionObject.downcast_to<Exception>()));
        }

        static void handle_error(Exception e)
        {
            e.add_to_log();
            resolve.dependency_for<IEventAggregator>().publish(new unhandled_error_occurred(e));
        }
    }
}