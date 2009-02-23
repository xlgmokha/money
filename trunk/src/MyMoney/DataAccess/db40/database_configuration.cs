using System.IO;
using Castle.Core;
using MyMoney.Presentation.Model.Projects;

namespace MyMoney.DataAccess.db40
{
    public interface IDatabaseConfiguration
    {
        IFile path_to_the_database();
        void change_path_to(IFile file);
    }

    [Singleton]
    public class database_configuration : IDatabaseConfiguration
    {
        file the_path_to_the_database_file;

        public database_configuration()
        {
            the_path_to_the_database_file = Path.GetTempFileName();
        }

        public IFile path_to_the_database()
        {
            return the_path_to_the_database_file;
        }

        public void change_path_to(IFile file)
        {
            the_path_to_the_database_file = Path.GetTempFileName();
            file.copy_to(the_path_to_the_database_file);
        }
    }
}