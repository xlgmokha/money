using System;
using System.Collections.Generic;
using Db4objects.Db4o;
using MoMoney.Presentation.Model.Projects;

namespace MoMoney.DataAccess.db40
{
    public interface ISession : IDisposable
    {
        bool represents(IFile file);
        IEnumerable<T> Query<T>();
        void Store<T>(T item);
        void Commit();
    }

    public class Session : ISession
    {
        readonly IObjectContainer connection;
        readonly IFile path;

        public Session(IObjectContainer connection, IFile path)
        {
            this.connection = connection;
            this.path = path;
        }

        public bool represents(IFile file)
        {
            return path.Equals(file);
        }

        public IEnumerable<T> Query<T>()
        {
            return connection.Query<T>();
        }

        public void Store<T>(T item)
        {
            connection.Store(item);
        }

        public void Commit()
        {
            connection.Commit();
        }

        public void Dispose()
        {
            //connection.Dispose();
        }
    }
}