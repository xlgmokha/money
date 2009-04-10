using MoMoney.Infrastructure.eventing;
using MoMoney.Infrastructure.transactions2;
using MoMoney.Presentation.Model.messages;
using MoMoney.Utility.Extensions;

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

    public class ProjectController : IProjectController, IEventSubscriber<UnsavedChangesEvent>
    {
        readonly IEventAggregator broker;
        readonly IDatabaseConfiguration configuration;
        IFile current_file;
        bool is_project_open = false;
        bool unsaved_changes = false;

        public ProjectController(IEventAggregator broker, IDatabaseConfiguration configuration)
        {
            this.broker = broker;
            this.configuration = configuration;
            broker.subscribe(this);
        }

        public string name()
        {
            return has_been_saved_at_least_once() ? current_file.path : "untitled.mo";
        }

        public void start_new_project()
        {
            close_project();
            is_project_open = true;
            current_file = null;
            broker.publish(new NewProjectOpened(name()));
        }

        public void open_project_from(IFile file)
        {
            if (!file.does_the_file_exist()) return;
            close_project();
            configuration.open(file);
            current_file = file;
            is_project_open = true;
            broker.publish(new NewProjectOpened(name()));
        }

        public void save_changes()
        {
            ensure_that_a_path_to_save_to_has_been_specified();
            configuration.copy_to(current_file.path);
            unsaved_changes = false;
            broker.publish<SavedChangesEvent>();
        }

        public void save_project_to(IFile new_file)
        {
            if (new_file.path.is_blank()) return;
            current_file = new_file;
            save_changes();
        }

        public void close_project()
        {
            if (!is_project_open) return;
            is_project_open = false;
            current_file = null;
            broker.publish<ClosingProjectEvent>();
        }

        public bool has_been_saved_at_least_once()
        {
            return current_file != null;
        }

        public bool has_unsaved_changes()
        {
            return unsaved_changes;
        }

        public bool is_open()
        {
            return is_project_open;
        }

        void ensure_that_a_path_to_save_to_has_been_specified()
        {
            if (!has_been_saved_at_least_once())
            {
                throw new FileNotSpecifiedException();
            }
        }

        public void notify(UnsavedChangesEvent message)
        {
            unsaved_changes = true;
        }
    }
}