using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using MoMoney.Presentation.Core;

namespace MoMoney.Presentation.Presenters.Commands
{
    public class RunTheSpecs
    {
    }

    [Concern(typeof (RunThe<>))]
    public class when_initializing_different_regions_of_the_user_interface :
        concerns_for<IRunThe<IPresenter>, RunThe<IPresenter>>
    {
        it should_initialize_the_presenter_that_controls_that_region =
            () => application_controller.was_told_to(x => x.run<IPresenter>());

        context c = () => { application_controller = the_dependency<IApplicationController>(); };

        because b = () => sut.run();

        static IApplicationController application_controller;
    }
}