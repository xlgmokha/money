using developwithpassion.bdd.contexts;
using MoMoney.Presentation.Model.Projects;
using MoMoney.Presentation.Views.dialogs;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Presentation.Model.Menu.File.Commands
{
    [Concern(typeof (save_as_command))]
    public class when_saving_the_current_project_to_a_new_file_path : concerns_for<ISaveAsCommand, save_as_command>
    {
        it should_save_the_current_project_to_the_new_path = () => current_project.was_told_to(x => x.save_to(new_path));

        context c = () =>
                        {
                            current_project = an<IProject>();
                            view = an<ISelectFileToSaveToDialog>();
                            new_path = "blah_blah";

                            when_the(view).is_told_to(x => x.tell_me_the_path_to_the_file()).it_will_return(new_path);
                        };

        because b = () => sut.run();

        public override ISaveAsCommand create_sut()
        {
            return new save_as_command(view, current_project);
        }

        static IProject current_project;
        static Projects.ApplicationFile new_path;
        static ISelectFileToSaveToDialog view;
    }
}