using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using momoney.presentation.presenters;
using momoney.presentation.views;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Winforms.Resources;

namespace momoney.modules
{
    [Concern(typeof (NotificationIconPresenter))]
    public abstract class behaves_like_notification_icon_presenter : concerns_for<NotificationIconPresenter>
    {
        context c = () =>
        {
            view = the_dependency<INotificationIconView>();
        };

        static protected INotificationIconView view;
    }

    public class when_initializing_the_notification_icon : behaves_like_notification_icon_presenter
    {
        it should_ask_the_view_to_display_the_correct_icon_and_text =
            () => view.was_told_to(v => v.display(ApplicationIcons.Application, "mokhan.ca"));

        context c = () =>
        {
            shell = an<Shell>();
        };

        because b = () => sut.present(shell);
        static Shell shell;
    }
}