using developwithpassion.bdd.contexts;
using Gorilla.Commons.Infrastructure.Eventing;
using Gorilla.Commons.Testing;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Views.Shell;
using MoMoney.Presentation.Winforms.Resources;

namespace MoMoney.Presentation.Presenters.Shell
{
    [Concern(typeof (StatusBarPresenter))]
    public class when_initializing_the_status_bar : concerns_for<IStatusBarPresenter, StatusBarPresenter>
    {
        it should_display_a_ready_message =
            () => view.was_told_to(v => v.display(ApplicationIcons.ApplicationReady, "Ready"));

        context c = () =>
                        {
                            view = the_dependency<IStatusBarView>();
                            broker = the_dependency<IEventAggregator>();
                        };

        because b = () => sut.notify(new NewProjectOpened(""));

        //public override IStatusBarPresenter create_sut()
        //{
        //    return new StatusBarPresenter(view, broker);
        //}

        static IStatusBarView view;
        static IEventAggregator broker;
    }
}