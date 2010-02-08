using NHibernate;
using presentation.windows.domain;

namespace presentation.windows.orm.nhibernate
{
    public class NHibernatePersonRepository : PersonRepository
    {
        ISession session;

        public NHibernatePersonRepository(ISession session)
        {
            this.session = session;
        }

        public void save(Person person)
        {
            session.Save(person);
        }
    }
}