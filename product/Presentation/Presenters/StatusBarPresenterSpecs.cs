using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Winforms.Resources;
using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Presentation.Presenters
{
    [Concern(typeof (StatusBarPresenter))]
    public class when_initializing_the_status_bar : concerns_for<IStatusBarPresenter, StatusBarPresenter>
    {
        it should_display_a_ready_message =
            () => view.was_told_to(v => v.display(ApplicationIcons.green_circle, "Ready"));

        context c = () =>
                        {
                            view = the_dependency<IStatusBarView>();
                            broker = the_dependency<IEventAggregator>();
                        };

        because b = () => sut.notify(new NewProjectOpened(""));

        static IStatusBarView view;
        static IEventAggregator broker;
    }
}