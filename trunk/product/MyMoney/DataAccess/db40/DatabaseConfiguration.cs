using System;
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
        IFile the_path_to_the_database_file;

        public IFile path_to_the_database()
        {
            ensure_that_a_path_is_specified();
            return the_path_to_the_database_file;
        }

        public void change_path_to(IFile file)
        {
            the_path_to_the_database_file = file;
        }

        void ensure_that_a_path_is_specified()
        {
            if (null == the_path_to_the_database_file)
            {
                throw new ArgumentException("A path to the database is not specified.");
            }
        }
    }
}