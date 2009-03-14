using Castle.Core;
using MoMoney.Presentation.Model.Projects;

namespace MoMoney.DataAccess.db40
{
    public interface IDatabaseConfiguration
    {
        IFile path_to_the_database();
        void change_path_to(IFile file);
    }

    [Singleton]
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        ApplicationFile the_path_to_the_database_file;

        public IFile path_to_the_database()
        {
            return the_path_to_the_database_file;
        }

        public void change_path_to(IFile file)
        {
            //the_path_to_the_database_file = Path.GetTempFileName();
            //file.copy_to(the_path_to_the_database_file);
            the_path_to_the_database_file = file.path;
        }
    }
}