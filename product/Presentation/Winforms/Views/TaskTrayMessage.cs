using Gorilla.Commons.Utility.Extensions;
using MoMoney.Presentation.Views.Shell;

namespace MoMoney.Presentation.Winforms.Views
{
    public class TaskTrayMessage : ITaskTrayMessageView
    {
        readonly INotificationIconView view;

        public TaskTrayMessage(INotificationIconView view)
        {
            this.view = view;
        }

        public void display(string message, params object[] arguments)
        {
            view.show_popup_message(message.formatted_using(arguments));
        }
    }
}