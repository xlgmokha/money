using Gorilla.Commons.Infrastructure.FileSystem;
using MoMoney.Infrastructure.transactions2;

namespace MoMoney.DataAccess
{
    public interface IConnectionFactory
    {
        IDatabaseConnection open_connection_to(IFile the_path_to_the_database_file);
    }
}