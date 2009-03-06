using jpboodhoo.bdd.contexts;
using MoMoney.Presentation.Core;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Presentation.Presenters.Commands
{
    [Concern(typeof (run_the<>))]
    public class when_initializing_different_regions_of_the_user_interface : concerns_for<IRunThe<IPresenter>, run_the<IPresenter>>
    {
        it should_initialize_the_presenter_that_controls_that_region =
            () => application_controller.was_told_to(x => x.run<IPresenter>());

        context c = () => { application_controller = the_dependency<IApplicationController>(); };

        //public override IRunThe<IPresenter> create_sut()
        //{
        //    return new run_the<IPresenter>(application_controller);
        //}

        because b = () => sut.run();

        static IApplicationController application_controller;
    }
}