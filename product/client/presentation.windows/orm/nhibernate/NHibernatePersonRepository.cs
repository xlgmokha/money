using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
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

        public Person find_by(Guid id)
        {
            return session.Linq<Person>().Single(x => x.id.Equals(id));
        }

        public IEnumerable<Person> find_all()
        {
            return session.Linq<Person>().ToList();
        }
    }
}