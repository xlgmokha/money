using System;
using System.Windows.Forms;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.eventing;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Presentation.Model.messages;

namespace MoMoney.boot
{
    internal class global_error_handling : ICommand
    {
        public void run()
        {
            Application.ThreadException += (sender, e) => handle(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (o, e) => handle(e.ExceptionObject.downcast_to<Exception>());
        }

        void handle(Exception e)
        {
            e.add_to_log();
            resolve.dependency_for<IEventAggregator>().publish(new UnhandledErrorOccurred(e));
        }
    }
}