using System;
using System.Windows.Forms;
using MyMoney.Infrastructure.Container;
using MyMoney.Infrastructure.eventing;
using MyMoney.Infrastructure.Extensions;
using MyMoney.Presentation.Model.messages;
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