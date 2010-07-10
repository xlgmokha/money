using Gorilla.Commons.Infrastructure.FileSystem;
using momoney.presentation.model.menu.file;
using MoMoney.Presentation.Model.Projects;
using momoney.presentation.views;

namespace tests.unit.client.presentation.model
{
    [Concern(typeof (SaveAsCommand))]
    public class when_saving_the_current_project_to_a_new_file_path : TestsFor<ISaveAsCommand>
    {
        it should_save_the_current_project_to_the_new_path = () => current_project.was_told_to(x => x.save_project_to(new_path));

        context c = () =>
        {
            current_project = an<IProjectController>();
            view = an<ISelectFileToSaveToDialog>();
            new_path = "blah_blah";

            view.is_told_to(x => x.tell_me_the_path_to_the_file()).it_will_return(new_path);
        };

        because b = () => sut.run();

        public override ISaveAsCommand create_sut()
        {
            return new SaveAsCommand(view, current_project);
        }

        static IProjectController current_project;
        static ApplicationFile new_path;
        static ISelectFileToSaveToDialog view;
    }
}