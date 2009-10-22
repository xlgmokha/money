using System;
using System.Windows.Forms;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.utility;
using momoney.presentation.model.events;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.boot
{
    class global_error_handling : Command
    {
        public void run()
        {
            Application.ThreadException += (sender, e) => handle(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (o, e) => handle(e.ExceptionObject.downcast_to<Exception>());
        }

        void handle(Exception e)
        {
            e.add_to_log();
            Resolve.the<IEventAggregator>().publish(new UnhandledErrorOccurred(e));
        }
    }
}