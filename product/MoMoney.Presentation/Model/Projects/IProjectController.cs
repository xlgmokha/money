using Gorilla.Commons.Infrastructure.FileSystem;

namespace MoMoney.Presentation.Model.Projects
{
    public interface IProjectController
    {
        string name();
        void start_new_project();
        void open_project_from(IFile file);
        void save_changes();
        void save_project_to(IFile new_file);
        void close_project();
        bool has_been_saved_at_least_once();
        bool has_unsaved_changes();
        bool is_open();
    }
}