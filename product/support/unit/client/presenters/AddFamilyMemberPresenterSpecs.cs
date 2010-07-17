using Machine.Specifications;
using presentation.windows;
using presentation.windows.presenters;

namespace unit.client.presenters
{
    [Subject(typeof(AddFamilyMemberPresenter))]
    public class AddFamilyMemberPresenterSpecs
    {
        public class concern : Helpers
        {
            Establish context = () =>
            {
                command_builder = a<UICommandBuilder>();

                sut = new AddFamilyMemberPresenter(command_builder);
            };

            static protected AddFamilyMemberPresenter sut;
            static protected UICommandBuilder command_builder;
        }

        public class when_clicking_on_the_save_button : concern
        {
            It should_invoke_the_save_command = () =>
            {
                save_command.received(x => x.Execute(null));
            };

            Establish context = () =>
            {
                save_command = a<IObservableCommand>();

                command_builder.is_told_to(x => x.build<AddFamilyMemberPresenter.SaveCommand>(sut)).it_will_return(save_command);
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