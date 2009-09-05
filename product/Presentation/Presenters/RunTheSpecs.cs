using developwithpassion.bdd.contexts;
using Gorilla.Commons.Infrastructure.Threading;
using Gorilla.Commons.Testing;
using MbUnit.Framework;
using MoMoney.Presentation.Core;

namespace MoMoney.Presentation.Presenters.Commands
{
    public class RunTheSpecs
    {
    }

    [Ignore]
    [Concern(typeof (RunThe<>))]
    public class when_initializing_different_regions_of_the_user_interface :
        concerns_for<IRunThe<IPresenter>, RunThe<IPresenter>>
    {
        //it should_initialize_the_presenter_that_controls_that_region = () => controller.was_told_to(x => x.run<IPresenter>());
        it should_initialize_the_presenter_that_controls_that_region = () => processor.was_told_to(x => x.add(() => controller.run<IPresenter>()));

        context c = () =>
                        {
                            controller = the_dependency<IApplicationController>();
                            processor = the_dependency<ICommandProcessor>();
                        };

        because b = () => sut.run();

        static IApplicationController controller;
        static ICommandProcessor processor;
    }
}