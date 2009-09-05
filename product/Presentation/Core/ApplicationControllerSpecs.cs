using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using MoMoney.Presentation.Views.Core;
using MoMoney.Presentation.Views.Shell;

namespace MoMoney.Presentation.Core
{
    [Concern(typeof (ApplicationController))]
    public abstract class behaves_like_an_application_controller :
        concerns_for<IApplicationController, ApplicationController>
    {
        context c = () =>
                        {
                            presenter_registry = the_dependency<IPresenterRegistry>();
                            shell = the_dependency<IShell>();
                        };

        static protected IShell shell;
        static protected IPresenterRegistry presenter_registry;
    }

    public class when_the_application_controller_is_asked_to_run_a_presenter : behaves_like_an_application_controller
    {
        context c = () =>
                        {
                            implementation_of_the_presenter = an<IPresenter>();
                            presenter_registry
                                .is_told_to(r => r.all())
                                .it_will_return(implementation_of_the_presenter);
                        };

        because b = () => sut.run<IPresenter>();

        it should_ask_the_registered_presenters_for_an_instance_of_the_presenter_to_run =
            () => presenter_registry.was_told_to(r => r.all());

        it should_initialize_the_presenter_to_run = () => implementation_of_the_presenter.was_told_to(p => p.run());

        static IPresenter implementation_of_the_presenter;
    }

    public class when_initializing_a_presenter_for_that_presents_a_content_view : behaves_like_an_application_controller
    {
        it should_add_the_content_view_to_the_window_shell = () => shell.was_told_to(x => x.add(view));

        context c = () =>
                        {
                            view = an<IDockedContentView>();
                            var presenter = an<IContentPresenter>();

                            presenter_registry.is_told_to(r => r.all()).it_will_return(presenter);
                            presenter.is_told_to(x => x.View).it_will_return(view);
                        };

        because b = () => sut.run<IContentPresenter>();

        static IDockedContentView view;
    }
}