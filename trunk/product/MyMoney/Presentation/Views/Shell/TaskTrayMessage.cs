using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Views.Shell
{
    public interface ITaskTrayMessageView
    {
        void display(string message, params object[] arguments);
    }

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