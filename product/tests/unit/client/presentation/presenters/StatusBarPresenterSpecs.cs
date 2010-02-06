using momoney.presentation.model.eventing;
using momoney.presentation.presenters;
using momoney.presentation.resources;
using MoMoney.Presentation.Views;

namespace tests.unit.client.presentation.presenters
{
    [Concern(typeof (StatusBarPresenter))]
    public class when_initializing_the_status_bar : tests_for<StatusBarPresenter>
    {
        it should_display_a_ready_message =
            () => view.was_told_to(v => v.display(ApplicationIcons.green_circle, "Ready"));

        context c = () =>
        {
            view = dependency<IStatusBarView>();
        };

        because b = () => sut.notify(new NewProjectOpened(""));

        static IStatusBarView view;
    }
}