using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using momoney.presentation.model.eventing;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Winforms.Resources;

namespace momoney.presentation.presenters
{
    [Concern(typeof (StatusBarPresenter))]
    public class when_initializing_the_status_bar : concerns_for<StatusBarPresenter>
    {
        it should_display_a_ready_message =
            () => view.was_told_to(v => v.display(ApplicationIcons.green_circle, "Ready"));

        context c = () =>
        {
            view = the_dependency<IStatusBarView>();
        };

        because b = () => sut.notify(new NewProjectOpened(""));

        static IStatusBarView view;
    }
}