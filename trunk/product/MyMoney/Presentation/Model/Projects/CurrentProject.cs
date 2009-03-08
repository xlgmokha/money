using System.IO;
using Castle.Core;
using MoMoney.DataAccess.db40;
using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Model.messages;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Model.Projects
{
    public interface IProject : IEventSubscriber<unsaved_changes_event>
    {
        string name();
        void start_a_new_project();
        void open(IFile file);
        void save_to(IFile new_file);
        bool has_been_saved_at_least_once();
        void save_changes();
        bool has_unsaved_changes();
        bool is_open();
        void close();
    }

    [Singleton]
    public class CurrentProject : IProject
    {
        readonly IDatabaseConfiguration configuration;
        readonly IEventAggregator broker;
        IFile current_file;
        bool is_project_open = false;
        bool changes_to_save = false;

        public CurrentProject(IDatabaseConfiguration configuration, IEventAggregator broker)
        {
            this.broker = broker;
            this.configuration = configuration;
            broker.subscribe_to(this);
        }

        public string name()
        {
            return has_been_saved_at_least_once() ? current_file.path : "untitled.mo";
        }

        public void open(IFile file)
        {
            if (!file.does_the_file_exist()) return;
            current_file = file;
            configuration.change_path_to(file);
            changes_to_save = false;
            broker.publish(new new_project_opened(name()));
        }

        public void start_a_new_project()
        {
            is_project_open = true;
            current_file = null;
            configuration.change_path_to((ApplicationFile) Path.GetTempFileName());
            changes_to_save = false;
            broker.publish(new new_project_opened(name()));
        }

        public void save_to(IFile new_file)
        {
            if (new_file.path.is_blank())
            {
                return;
            }
            current_file = new_file;
            save_changes();
        }

        public bool has_been_saved_at_least_once()
        {
            return current_file != null;
        }

        public void save_changes()
        {
            ensure_that_a_path_to_save_to_has_been_specified();
            configuration.path_to_the_database().copy_to(current_file);
            changes_to_save = false;
            broker.publish<saved_changes_event>();
        }

        public bool has_unsaved_changes()
        {
            return changes_to_save;
        }

        public bool is_open()
        {
            return is_project_open;
        }

        public void close()
        {
            is_project_open = false;
            changes_to_save = false;
            broker.publish<closing_project_event>();
        }

        void ensure_that_a_path_to_save_to_has_been_specified()
        {
            if (!has_been_saved_at_least_once())
            {
                throw new file_not_specified_exception();
            }
        }

        public void notify(unsaved_changes_event message)
        {
            changes_to_save = true;
        }
    }
}