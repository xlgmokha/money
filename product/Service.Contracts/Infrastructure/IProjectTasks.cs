using Gorilla.Commons.Infrastructure.FileSystem;

namespace MoMoney.Service.Contracts.Infrastructure
{
    public interface IProjectTasks
    {
        void open(IFile file);
        void copy_to(string path);
        void close(string path);
    }
}