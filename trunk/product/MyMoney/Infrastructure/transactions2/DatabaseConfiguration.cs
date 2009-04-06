using System;
using System.IO;
using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Model.Projects;

namespace MoMoney.Infrastructure.transactions2
{
    public interface IDatabaseConfiguration
    {
        IFile path_to_database();
        void change_path_to(IFile file);
    }

    public class DatabaseConfiguration : IDatabaseConfiguration, IEventSubscriber<NewProjectOpened>
    {
        IFile path;
        readonly object mutex = new object();

        public DatabaseConfiguration()
        {
            path = new ApplicationFile(Path.GetTempFileName());
        }

        public IFile path_to_database()
        {
            lock (mutex) return path;
        }

        public void change_path_to(IFile file)
        {
            path = new ApplicationFile(Path.GetTempFileName());
            file.copy_to(path.path);
        }

        public void notify(NewProjectOpened message)
        {
            within_lock(() => path = new ApplicationFile(Path.GetTempFileName()));
        }

        void within_lock(Action action)
        {
            lock (mutex) action();
        }
    }
}