using jpboodhoo.bdd.contexts;
using MyMoney.Infrastructure.eventing;
using MyMoney.Presentation.Model.messages;
using MyMoney.Presentation.Resources;
using MyMoney.Presentation.Views.Shell;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Presentation.Presenters.Shell
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

        because b = () => sut.notify(new new_project_opened(""));

        public override IStatusBarPresenter create_sut()
        {
            return new StatusBarPresenter(view, broker);
        }

        static IStatusBarView view;
        static IEventAggregator broker;
    }
}