using System;
using System.Windows.Forms;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.eventing;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Presentation.Context;
using MoMoney.Presentation.Model.messages;
using MoMoney.Utility.Core;

namespace MoMoney.windows.ui
{
    internal class start_the_application : ICommand
    {
        public void run()
        {
            try
            {
                Application.Run(resolve.dependency_for<the_application_context>());
            }
            catch (Exception e)
            {
                this.log().error(e);
                resolve.dependency_for<IEventAggregator>().publish(new unhandled_error_occurred(e));
            }
        }
    }
}