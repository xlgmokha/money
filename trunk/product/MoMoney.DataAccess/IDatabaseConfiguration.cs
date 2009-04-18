using Gorilla.Commons.Infrastructure.FileSystem;

namespace MoMoney.DataAccess
{
    public interface IDatabaseConfiguration
    {
        void open(IFile file);
        void copy_to(string path);
        void close(string name);
    }
}