using Gorilla.Commons.Infrastructure.FileSystem;

namespace momoney.database
{
    public interface IDatabaseConfiguration
    {
        void open(File file);
        void copy_to(string path);
        void close(string name);
    }
}