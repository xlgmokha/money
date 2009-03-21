using MoMoney.DataAccess.db40;
using MoMoney.Infrastructure.eventing;
using MoMoney.Infrastructure.transactions;
using MoMoney.Presentation.Model.messages;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Model.Projects
{
    public interface IProject
    {
        string name();
        void start_new_project();
        void open_project_from(IFile file);
        void save_changes();
        void save_project_to(IFile new_file);
        void close_project();
        bool has_been_saved_at_least_once();
        bool has_unsaved_changes();
    }

    public class CurrentProject : IProject
    {
        readonly IEventAggregator broker;
        readonly IUnitOfWorkRegistry registry;
        readonly ISessionContext context;
        IFile current_file;
        bool is_project_open = false;

        public CurrentProject(IEventAggregator broker, IUnitOfWorkRegistry registry, ISessionContext context)
        {
            this.broker = broker;
            this.registry = registry;
            this.context = context;
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
            broker.publish(new new_project_opened(name()));
        }

        public void open_project_from(IFile file)
        {
            if (!file.does_the_file_exist()) return;
            close_project();
            current_file = file;
            is_project_open = true;
            context.start_session_for(current_file);
            broker.publish(new new_project_opened(name()));
        }

        public void save_changes()
        {
            ensure_that_a_path_to_save_to_has_been_specified();
            registry.commit_all();
            registry.Dispose();
            context.commit_current_session();
            broker.publish<saved_changes_event>();
        }

        public void save_project_to(IFile new_file)
        {
            if (new_file.path.is_blank()) return;

            context.start_session_for(new_file);
            current_file = new_file;
            save_changes();
        }

        public void close_project()
        {
            if (!is_project_open) return;
            registry.Dispose();
            context.close_session_to(current_file);
            is_project_open = false;
            broker.publish<closing_project_event>();
        }

        public bool has_been_saved_at_least_once()
        {
            return current_file != null;
        }

        public bool has_unsaved_changes()
        {
            return registry.has_changes_to_commit();
        }

        void ensure_that_a_path_to_save_to_has_been_specified()
        {
            if (!has_been_saved_at_least_once())
            {
                throw new file_not_specified_exception();
            }
        }
    }
}