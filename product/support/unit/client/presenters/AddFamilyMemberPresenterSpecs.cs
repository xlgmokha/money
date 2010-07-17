using Machine.Specifications;
using Moq;
using presentation.windows;
using presentation.windows.presenters;
using It = Machine.Specifications.It;

namespace unit.client.presenters
{
    public class AddFamilyMemberPresenterSpecs
    {
        public class concern
        {
            Establish context = () =>
            {
                command_builder = new Mock<UICommandBuilder>();

                sut = new AddFamilyMemberPresenter(command_builder.Object);
            };

            static protected AddFamilyMemberPresenter sut;
            static protected Mock<UICommandBuilder> command_builder;
        }

        public class when_clicking_on_the_save_button : concern
        {
            It should_invoke_the_save_command = () =>
            {
                save_command.received(x => x.Execute(null));
            };

            Establish context = () =>
            {
                save_command = new Mock<IObservableCommand>();

                command_builder.Setup(x => x.build<AddFamilyMemberPresenter.SaveCommand>(sut)).Returns(save_command.Object);
            };

            Because b = () =>
            {
                sut.present();
                sut.Save.Execute(null);
            };

            static Mock<IObservableCommand> save_command;
        }
    }
}