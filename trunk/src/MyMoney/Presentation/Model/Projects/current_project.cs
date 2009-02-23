using System.IO;
using Castle.Core;
using MyMoney.DataAccess.db40;
using MyMoney.Infrastructure.eventing;
using MyMoney.Presentation.Model.messages;

namespace MyMoney.Presentation.Model.Projects
{
    public interface IProject
    {
        string name();
        void start_a_new_project();
        void open(IFile file);
        void save_to(IFile new_file);
        bool has_been_saved_at_least_once();
        void save_changes();
    }

    [Singleton]
    public class current_project : IProject
    {
        private readonly IDatabaseConfiguration configuration;
        private readonly IEventAggregator broker;
        private IFile current_file;

        public current_project(IDatabaseConfiguration configuration, IEventAggregator broker)
        {
            this.broker = broker;
            this.configuration = configuration;
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
            broker.publish(new new_project_opened(name()));
        }

        public void start_a_new_project()
        {
            current_file = null;
            configuration.change_path_to((file) Path.GetTempFileName());
            broker.publish(new new_project_opened(name()));
        }

        public void save_to(IFile new_file)
        {
            if (string.IsNullOrEmpty(new_file.path)) {
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
            broker.publish<saved_changes_event>();
        }

        private void ensure_that_a_path_to_save_to_has_been_specified()
        {
            if (!has_been_saved_at_least_once()) {
                throw new file_not_specified_exception();
            }
        }
    }
}