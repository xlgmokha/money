using Autofac;
using Machine.Specifications;
using Moq;
using presentation.windows;
using presentation.windows.presenters;
using It = Machine.Specifications.It;

namespace unit.client.presenters
{
    public class WPFCommandBuilderSpecs
    {
        public class concern
        {
            Establish context = () =>
            {
                container = new Mock<IContainer>();
                sut = new WPFCommandBuilder(container.Object);
            };

            static protected WPFCommandBuilder sut;
            static protected Mock<IContainer> container;
        }

        public class when_building_a_command_to_bind_to_a_presenter : concern
        {
            It should_return_a_command_that_executes_the_command_when_run = () =>
            {
                command.received(x => x.run(presenter.Object));
            };

            Establish context = () =>
            {
                presenter = a<Presenter>();
                command = a<UICommand>();
                container.Setup(x => x.Resolve<UICommand>()).Returns(command.Object);
            };

            static Mock<T> a<T>() where T : class
            {
                return new Mock<T>();
            }

            Because b = () =>
            {
                sut.build<UICommand>(presenter.Object).Execute(null);
            };

            static Mock<Presenter> presenter;
            static Mock<UICommand> command;
        }
    }
}