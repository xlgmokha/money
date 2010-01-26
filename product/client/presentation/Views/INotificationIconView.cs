using System;
using MoMoney.Presentation.Winforms.Resources;

namespace momoney.presentation.views
{
    public interface INotificationIconView : IDisposable
    {
        void display(ApplicationIcon icon_to_display, string text_to_display);
        void opened_new_project();
        void show_popup_message(string message);
    }
}