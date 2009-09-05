using System;
using System.Windows.Forms;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.Eventing;
using Gorilla.Commons.Infrastructure.Logging;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Presentation.Model.messages;

namespace MoMoney.boot
{
    class global_error_handling : ICommand
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