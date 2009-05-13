using System;
using Gorilla.Commons.Windows.Forms.Resources;

namespace MoMoney.Presentation.Views.Shell
{
    public interface INotificationIconView : IDisposable
    {
        void display(ApplicationIcon icon_to_display, string text_to_display);
        void opened_new_project();
        void show_popup_message(string message);
    }
}