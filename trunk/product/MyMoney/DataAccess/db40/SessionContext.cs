using System.Collections.Generic;
using Db4objects.Db4o;
using MoMoney.Presentation.Model.Projects;

namespace MoMoney.DataAccess.db40
{
    public interface ISessionContext
    {
        void start_session_for(IFile file);
        ISession current_session();
        void close_session_to(IFile file);
        void commit_current_session();
    }

    public class SessionContext : ISessionContext
    {
        readonly IConnectionFactory connection_factory;
        readonly IDictionary<IFile, IObjectContainer> sessions;
        ISession session;

        public SessionContext(IConnectionFactory connection_factory)
        {
            this.connection_factory = connection_factory;
            session = new DetachedSession();
            sessions = new Dictionary<IFile, IObjectContainer>();
        }

        public void start_session_for(IFile file)
        {
            var container = connection_factory.open_connection_to(file);
            sessions.Add(file, container);
            session = new AttachedSession(container);
        }

        public ISession current_session()
        {
            if (null == session) session = new DetachedSession();
            return session;
        }

        public void close_session_to(IFile file)
        {
            if (null == file || !sessions.ContainsKey(file)) return;
            sessions[file].Dispose();
            sessions.Remove(file);
        }

        public void commit_current_session()
        {
            current_session().commit();
        }
    }
}