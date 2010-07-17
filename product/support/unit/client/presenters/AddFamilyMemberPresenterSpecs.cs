using Machine.Specifications;
using presentation.windows;
using presentation.windows.presenters;
using Rhino.Mocks;

namespace unit.client.presenters
{
    public class AddFamilyMemberPresenterSpecs
    {
        public class concern
        {
            Establish context = () =>
            {
                command_builder = MockRepository.GenerateMock<UICommandBuilder>();

                sut = new AddFamilyMemberPresenter(command_builder);
            };

            static protected AddFamilyMemberPresenter sut;
            static protected UICommandBuilder command_builder;
        }

        public class when_clicking_on_the_save_button : concern
        {
            It should_invoke_the_save_command = () =>
            {
                save_command.AssertWasCalled(x => x.Execute(null));
            };

            Establish context = () =>
            {
                save_command = MockRepository.GenerateMock<IObservableCommand>();

                command_builder.Stub(x => x.build<AddFamilyMemberPresenter.SaveCommand>(sut)).Return(save_command);
            };

            Because b = () =>
            {
                sut.present();
                sut.Save.Execute(null);
            };

            static IObservableCommand save_command;
        }
    }
}