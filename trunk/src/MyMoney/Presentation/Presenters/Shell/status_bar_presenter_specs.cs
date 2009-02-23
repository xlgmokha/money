using jpboodhoo.bdd.contexts;
using MyMoney.Presentation.Resources;
using MyMoney.Presentation.Views.Shell;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;

namespace MyMoney.Presentation.Presenters.Shell
{
    [Concern(typeof (status_bar_presenter))]
    public class when_initializing_the_status_bar : concerns_for<IStatusBarPresenter, status_bar_presenter>
    {
        it should_display_a_ready_message =
            () => view.was_told_to(v => v.Display(ApplicationIcons.ApplicationReady, "Ready"));

        context c = () => { view = an<IStatusBarView>(); };

        because b = () => sut.run();

        public override IStatusBarPresenter create_sut()
        {
            return new status_bar_presenter(view);
        }

        static IStatusBarView view;
    }
}