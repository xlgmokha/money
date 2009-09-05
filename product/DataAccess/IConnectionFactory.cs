using Gorilla.Commons.Infrastructure.FileSystem;
using Gorilla.Commons.Infrastructure.Transactions;

namespace MoMoney.DataAccess
{
    public interface IConnectionFactory
    {
        IDatabaseConnection open_connection_to(IFile the_path_to_the_database_file);
    }
}