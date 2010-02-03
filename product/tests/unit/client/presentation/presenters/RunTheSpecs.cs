using developwithpassion.bdd.contexts;
using MbUnit.Framework;
using MoMoney.Presentation.Core;
using momoney.presentation.presenters;
using MoMoney.Service.Infrastructure.Threading;

namespace tests.unit.client.presentation.presenters
{
    public class RunTheSpecs
    {
        [Ignore]
        [Concern(typeof (RunThe<>))]
        public class when_initializing_different_regions_of_the_user_interface :
            concerns_for<IRunThe<Presenter>, RunThe<Presenter>>
        {
            it should_initialize_the_presenter_that_controls_that_region = () => processor.was_told_to(x => x.add(() => controller.run<Presenter>()));

            context c = () =>
            {
                controller = the_dependency<IApplicationController>();
                processor = the_dependency<CommandProcessor>();
            };

            because b = () => sut.run();

            static IApplicationController controller;
            static CommandProcessor processor;
        }
    }
}