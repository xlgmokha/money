using System;
using System.Windows.Forms;
using MyMoney.Infrastructure.Container;
using MyMoney.Infrastructure.eventing;
using MyMoney.Infrastructure.Extensions;
using MyMoney.Presentation.Context;
using MyMoney.Presentation.Model.messages;
using MyMoney.Utility.Core;

namespace MyMoney.windows.ui
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
                //MessageBox.Show(e.ToString(), e.Message);
            }
        }
    }
}