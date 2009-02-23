using System;

namespace MyMoney.Presentation.Views.Shell
{
    public interface ITaskTrayMessageView
    {
        void display(string message, params object[] arguments);
    }

    public class task_tray_message : ITaskTrayMessageView, IDisposable
    {
        public void display(string message, params object[] arguments)
        {
        }

        public void Dispose()
        {
        }
    }
}