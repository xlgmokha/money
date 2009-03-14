using Db4objects.Db4o;
using MoMoney.Presentation.Model.Projects;

namespace MoMoney.DataAccess.db40
{
    public interface IConnectionFactory
    {
        ISession open_connection_to(IFile the_path_to_the_database_file);
    }

    public class ConnectionFactory : IConnectionFactory
    {
        public ISession open_connection_to(IFile the_path_to_the_database_file)
        {
            return new Session(Db4oFactory.OpenFile(the_path_to_the_database_file.path), the_path_to_the_database_file);
        }
    }
}