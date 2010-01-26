using Gorilla.Commons.Infrastructure.FileSystem;
using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.utility;
using momoney.presentation.model.eventing;
using momoney.service.infrastructure;
using MoMoney.Service.Infrastructure.Eventing;
using momoney.service.infrastructure.transactions;

namespace MoMoney.Presentation.Model.Projects
{
    public class ProjectController : IProjectController, Callback<IUnitOfWork>
    {
        readonly IEventAggregator broker;
        readonly IProjectTasks configuration;
        IProject project;
        bool unsaved_changes = false;

        public ProjectController(IEventAggregator broker, IProjectTasks configuration)
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

        public void open_project_from(File file)
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

        public void save_project_to(File new_file)
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

        public void run(IUnitOfWork item)
        {
            unsaved_changes = item.is_dirty();
            if (unsaved_changes)
            {
                this.log().debug("unsaved changes: {0}", unsaved_changes);
                broker.publish<UnsavedChangesEvent>();
            }
        }
    }
}