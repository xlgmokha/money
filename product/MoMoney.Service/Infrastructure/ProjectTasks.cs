using Gorilla.Commons.Infrastructure.FileSystem;
using MoMoney.DataAccess;

namespace MoMoney.Service.Infrastructure
{
    public interface IProjectTasks
    {
        void open(IFile file);
        void copy_to(string path);
        void close(string path);
    }

    public class ProjectTasks : IProjectTasks
    {
        readonly IDatabaseConfiguration configuration;

        public ProjectTasks(IDatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void open(IFile file)
        {
            configuration.open(file);
        }

        public void copy_to(string path)
        {
            configuration.copy_to(path);
        }

        public void close(string path)
        {
            configuration.close(path);
        }
    }
}