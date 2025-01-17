using MoMoney.Presentation.Core;
using momoney.presentation.views;

namespace tests.unit.client.presentation.core
{
    public class ApplicationControllerSpecs
    {
        public abstract class concern : runner<ApplicationController>
        {
            context c = () =>
            {
                presenter_factory = dependency<PresenterFactory>();
                view_factory = dependency<ViewFactory>();
                shell = dependency<Shell>();
            };

            static protected Shell shell;
            static protected PresenterFactory presenter_factory;
            static protected ViewFactory view_factory;
        }

        [Concern(typeof (ApplicationController))]
        public class when_the_application_controller_is_asked_to_run_a_presenter : concern
        {
            context c = () =>
            {
                implementation_of_the_presenter = an<Presenter>();
                view = an<View<Presenter>>();
                presenter_factory
                    .is_told_to(r => r.create<Presenter>())
                    .it_will_return(implementation_of_the_presenter);
                view_factory.is_told_to(x => x.create_for<Presenter>()).it_will_return(view);
            };

            because b = () => sut.run<Presenter>();

            it should_initialize_the_presenter_to_run =
                () => implementation_of_the_presenter.was_told_to(p => p.present(shell));

            static Presenter implementation_of_the_presenter;
            static View<Presenter> view;
        }
    }
}