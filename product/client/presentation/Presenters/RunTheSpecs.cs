using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using MbUnit.Framework;
using MoMoney.Presentation.Core;
using MoMoney.Service.Infrastructure.Threading;

namespace momoney.presentation.presenters
{
    public class RunTheSpecs
    {
        [Ignore]
        [Concern(typeof (RunThe<>))]
        public class when_initializing_different_regions_of_the_user_interface :
            concerns_for<IRunThe<Presenter>, RunThe<Presenter>>
        {
            //it should_initialize_the_presenter_that_controls_that_region = () => controller.was_told_to(x => x.run<IPresenter>());
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