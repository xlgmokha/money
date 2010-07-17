using Autofac;
using Machine.Specifications;
using presentation.windows;
using presentation.windows.presenters;
using Rhino.Mocks;

namespace unit.client.presenters
{
    public class WPFCommandBuilderSpecs
    {
        public class concern
        {
            Establish context = () =>
            {
                container = a<IContainer>();
                sut = new WPFCommandBuilder(container);
            };

            static public T a<T>() where T : class
            {
                return MockRepository.GenerateMock<T>();
            }

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
                container.Stub(x => x.Resolve<UICommand>()).Return(command);
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