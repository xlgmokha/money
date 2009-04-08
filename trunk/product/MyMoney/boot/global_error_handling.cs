using System;
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
            //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += (sender, e) => handle(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (o, e) => handle(e.ExceptionObject.downcast_to<Exception>());
        }

        void handle(Exception e)
        {
            e.add_to_log();
            resolve.dependency_for<IEventAggregator>().publish(new unhandled_error_occurred(e));
        }
    }
}