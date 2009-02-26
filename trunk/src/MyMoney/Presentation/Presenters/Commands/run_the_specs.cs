using jpboodhoo.bdd.contexts;
using MyMoney.Presentation.Core;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Presentation.Presenters.Commands
{
    [Concern(typeof (run_the<>))]
    public class when_initializing_a_different_regions_of_the_user_interface :
        concerns_for<IRunThe<IPresenter>, run_the<IPresenter>>
    {
        it should_initialize_the_presenter_that_controls_that_region =
            () => application_controller.was_told_to(x => x.run<IPresenter>());

        context c = () => { application_controller = an<IApplicationController>(); };

        public override IRunThe<IPresenter> create_sut()
        {
            return new run_the<IPresenter>(application_controller);
        }

        because b = () => sut.run();

        static IApplicationController application_controller;
    }
}