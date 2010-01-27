using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Core
{
    public class ApplicationControllerSpecs
    {
        [Concern(typeof (ApplicationController))]
        public abstract class concern : concerns_for<IApplicationController, ApplicationController>
        {
            context c = () =>
                        {
                            presenter_factory = the_dependency<PresenterFactory>();
                            shell = the_dependency<Shell>();
                        };

            static protected Shell shell;
            static protected PresenterFactory presenter_factory;
        }

        public class when_the_application_controller_is_asked_to_run_a_presenter : concern
        {
            context c = () =>
                        {
                            implementation_of_the_presenter = an<Presenter>();
                            presenter_factory
                                .is_told_to(r => r.create<Presenter>())
                                .it_will_return(implementation_of_the_presenter);
                        };

            because b = () => sut.run<Presenter>();

            it should_initialize_the_presenter_to_run =
                () => implementation_of_the_presenter.was_told_to(p => p.present(shell));

            static Presenter implementation_of_the_presenter;
        }
    }
}