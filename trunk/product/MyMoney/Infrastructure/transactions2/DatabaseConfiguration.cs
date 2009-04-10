using System.IO;
using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Model.Projects;

namespace MoMoney.Infrastructure.transactions2
{
    public interface IDatabaseConfiguration
    {
        IFile path_to_database();
        void open(IFile file);
        void copy_to(string path);
    }

    //public class DatabaseConfiguration : IDatabaseConfiguration, IEventSubscriber<NewProjectOpened>
    //{
    //    IFile path;

    //    public DatabaseConfiguration()
    //    {
    //        path = new ApplicationFile(Path.GetTempFileName());
    //    }

    //    public IFile path_to_database()
    //    {
    //        return path;
    //    }

    //    public void open(IFile file)
    //    {
    //        path = new ApplicationFile(Path.GetTempFileName());
    //        file.copy_to(path.path);
    //    }

    //    public void copy_to(string new_path)
    //    {
    //        path.copy_to(new_path);
    //    }

    //    public void notify(NewProjectOpened message)
    //    {
    //        path = new ApplicationFile(Path.GetTempFileName());
    //    }
    //}
}