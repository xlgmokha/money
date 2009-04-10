using MoMoney.Infrastructure.eventing;
using MoMoney.Infrastructure.transactions2;
using MoMoney.Presentation.Model.messages;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Model.Projects
{
    public class ProjectController : IProjectController, IEventSubscriber<UnsavedChangesEvent>
    {
        readonly IEventAggregator broker;
        readonly IDatabaseConfiguration configuration;
        IProject project;
        bool unsaved_changes = false;

        public ProjectController(IEventAggregator broker, IDatabaseConfiguration configuration)
        {
            this.broker = broker;
            this.configuration = configuration;
            broker.subscribe(this);
            project = new EmptyProject();
        }

        public string name()
        {
            return project.name();
        }

        public void start_new_project()
        {
            close_project();
            project = new Project(null);
            broker.publish(new NewProjectOpened(name()));
        }

        public void open_project_from(IFile file)
        {
            if (!file.does_the_file_exist()) return;
            close_project();
            configuration.open(file);
            project = new Project(file);
            broker.publish(new NewProjectOpened(name()));
        }

        public void save_changes()
        {
            ensure_that_a_path_to_save_to_has_been_specified();
            configuration.copy_to(project.name());
            unsaved_changes = false;
            broker.publish<SavedChangesEvent>();
        }

        public void save_project_to(IFile new_file)
        {
            if (new_file.path.is_blank()) return;
            project = new Project(new_file);
            save_changes();
        }

        public void close_project()
        {
            if (!project.is_open()) return;
            configuration.close(project.name());
            project = new EmptyProject();
            broker.publish<ClosingProjectEvent>();
        }

        public bool has_been_saved_at_least_once()
        {
            return project.is_file_specified();
        }

        public bool has_unsaved_changes()
        {
            return unsaved_changes;
        }

        public bool is_open()
        {
            return project.is_open();
        }

        void ensure_that_a_path_to_save_to_has_been_specified()
        {
            if (!has_been_saved_at_least_once()) throw new FileNotSpecifiedException();
        }

        public void notify(UnsavedChangesEvent message)
        {
            unsaved_changes = true;
        }
    }

    public class EmptyProject : IProject
    {
        public string name()
        {
            return "untitled.mo";
        }

        public bool is_file_specified()
        {
            return false;
        }

        public bool is_open()
        {
            return false;
        }
    }

    public class Project : IProject
    {
        readonly IFile file;

        public Project(IFile file)
        {
            this.file = file;
        }

        public string name()
        {
            return is_file_specified() ? file.path : "untitled.mo";
        }

        public bool is_file_specified()
        {
            return file != null;
        }

        public bool is_open()
        {
            return true;
        }
    }
}