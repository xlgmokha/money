using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.utility;
using momoney.presentation.presenters;
using momoney.presentation.views;

namespace MoMoney.Presentation.Winforms.Views
{
    public class TaskTrayMessage : ITaskTrayMessageView
    {
        public void display(string message, params object[] arguments)
        {
            Resolve.the<INotificationIconView>().show_popup_message(message.formatted_using(arguments));
        }

        public void attach_to(TaskTrayPresenter presenter) {}
    }
}