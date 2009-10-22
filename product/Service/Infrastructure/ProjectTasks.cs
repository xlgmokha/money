using Gorilla.Commons.Infrastructure.FileSystem;
using momoney.database;
using MoMoney.Service.Contracts.Infrastructure;

namespace MoMoney.Service.Infrastructure
{
    public class ProjectTasks : IProjectTasks
    {
        readonly IDatabaseConfiguration configuration;

        public ProjectTasks(IDatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void open(File file)
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