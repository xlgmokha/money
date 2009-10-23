using Gorilla.Commons.Infrastructure.FileSystem;

namespace momoney.service.infrastructure
{
    public interface IProjectTasks
    {
        void open(File file);
        void copy_to(string path);
        void close(string path);
    }
}