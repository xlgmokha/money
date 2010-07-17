using Autofac;
using Machine.Specifications;
using presentation.windows;
using presentation.windows.presenters;

namespace unit.client.presenters
{
    [Subject(typeof (WPFCommandBuilder))]
    public class WPFCommandBuilderSpecs
    {
        public class concern : Helpers
        {
            Establish context = () =>
            {
                container = a<IContainer>();
                sut = new WPFCommandBuilder(container);
            };

            static protected WPFCommandBuilder sut;
            static protected IContainer container;
        }

        public class when_building_a_command_to_bind_to_a_presenter : concern
        {
            It should_return_a_command_that_executes_the_command_when_run = () =>
            {
                command.received(x => x.run(presenter));
            };

            Establish context = () =>
            {
                presenter = a<Presenter>();
                command = a<UICommand>();
                container.is_told_to(x => x.Resolve<UICommand>()).it_will_return(command);
            };

            Because b = () =>
            {
                sut.build<UICommand>(presenter).Execute(null);
            };

            static Presenter presenter;
            static UICommand command;
        }
    }
}