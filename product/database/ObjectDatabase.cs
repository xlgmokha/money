using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Gorilla.Commons.Infrastructure.FileSystem;
using gorilla.commons.utility;
using momoney.database.transactions;
using File = Gorilla.Commons.Infrastructure.FileSystem.File;

namespace momoney.database
{
    public class ObjectDatabase : IDatabase, IDatabaseConfiguration
    {
        readonly IConnectionFactory factory;
        File path;

        public ObjectDatabase(IConnectionFactory factory)
        {
            this.factory = factory;
            path = new ApplicationFile(Path.GetTempFileName());
        }

        public IEnumerable<T> fetch_all<T>() where T : Identifiable<Guid>
        {
            using (var connection = factory.open_connection_to(path_to_database()))
            {
                return connection.query<T>().ToList();
            }
        }

        public void apply(IStatement statement)
        {
            using (var connection = factory.open_connection_to(path_to_database()))
            {
                statement.prepare(connection);
                connection.commit();
            }
        }

        public void open(File file)
        {
            path = new ApplicationFile(Path.GetTempFileName());
            file.copy_to(path.path);
        }

        public void copy_to(string new_path)
        {
            path.copy_to(new_path);
        }

        public void close(string name)
        {
            path.delete();
            path = new ApplicationFile(Path.GetTempFileName());
        }

        File path_to_database()
        {
            return path;
        }
    }
}