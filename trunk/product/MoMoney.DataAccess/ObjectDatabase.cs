using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Gorilla.Commons.Infrastructure.FileSystem;
using Gorilla.Commons.Utility.Core;
using MoMoney.Domain.Core;
using MoMoney.Infrastructure.transactions2;

namespace MoMoney.DataAccess
{
    public class ObjectDatabase : IDatabase, IDatabaseConfiguration
    {
        readonly IConnectionFactory factory;
        IFile path;

        public ObjectDatabase(IConnectionFactory factory)
        {
            this.factory = factory;
            path = new ApplicationFile(Path.GetTempFileName());
        }

        public IEnumerable<T> fetch_all<T>() where T : IIdentifiable<Guid>
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

        public void open(IFile file)
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

        IFile path_to_database()
        {
            return path;
        }
    }
}