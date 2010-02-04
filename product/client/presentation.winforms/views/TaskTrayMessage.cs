using System;
using gorilla.commons.utility;
using momoney.presentation.presenters;
using momoney.presentation.views;

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

        public void attach_to(TaskTrayPresenter presenter)
        {
        }

        public IAsyncResult BeginInvoke(Delegate method, object[] args)
        {
            throw new NotImplementedException();
        }

        public object EndInvoke(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public object Invoke(Delegate method, object[] args)
        {
            throw new NotImplementedException();
        }

        public bool InvokeRequired
        {
            get { throw new NotImplementedException(); }
        }

        public void Dispose()
        {
        }
    }
}