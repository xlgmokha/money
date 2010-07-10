using NHibernate;
using presentation.windows.server.domain.accounting;

namespace presentation.windows.server.orm.nhibernate
{
    public class NHibernateAccountRepository : AccountRepository
    {
        ISession session;

        public NHibernateAccountRepository(ISession session)
        {
            this.session = session;
        }

        public void save(Account account)
        {
            session.Save(account);
        }
    }
}