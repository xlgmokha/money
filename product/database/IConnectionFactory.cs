using Gorilla.Commons.Infrastructure.FileSystem;
using momoney.database.transactions;

namespace momoney.database
{
    public interface IConnectionFactory
    {
        IDatabaseConnection open_connection_to(File the_path_to_the_database_file);
    }
}