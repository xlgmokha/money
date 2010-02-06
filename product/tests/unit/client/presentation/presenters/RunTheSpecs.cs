using MoMoney.Presentation.Core;
using momoney.presentation.presenters;

namespace tests.unit.client.presentation.presenters
{
    public class RunTheSpecs
    {
        [Concern(typeof (RunThe<>))]
        public class when_initializing_different_regions_of_the_user_interface : runner<RunThe<Presenter>>
        {
            it should_initialize_the_presenter_that_controls_that_region = () => controller.was_told_to(x => x.run<Presenter>());

            context c = () =>
            {
                controller = dependency<IApplicationController>();
            };

            because b = () => sut.run();

            static IApplicationController controller;
        }
    }
}