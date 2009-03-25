using System;
using System.Windows.Forms;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.eventing;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Infrastructure.interceptors;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Views.Shell;
using MoMoney.Utility.Core;

namespace MoMoney.boot
{
    internal class start_the_application : ICommand
    {
        ILoadPresentationModulesCommand command;

        public start_the_application() : this(Lazy.load<ILoadPresentationModulesCommand>())
        {
        }

        public start_the_application(ILoadPresentationModulesCommand command)
        {
            this.command = command;
        }

        public void run()
        {
            try
            {
                command.run();
                Application.Run(resolve.dependency_for<ApplicationShell>());
            }
            catch (Exception e)
            {
                this.log().error(e);
                resolve.dependency_for<IEventAggregator>().publish(new unhandled_error_occurred(e));
            }
        }
    }
}