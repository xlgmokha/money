using System;
using System.Collections.Generic;
using System.Linq;
using gorilla.commons.utility;
using momoney.database.transactions;
using MoMoney.Domain.Accounting;
using MoMoney.Domain.repositories;

namespace momoney.database.repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        readonly ISession session;

        public CompanyRepository(ISession session)
        {
            this.session = session;
        }

        public IEnumerable<ICompany> all()
        {
            return session.all<ICompany>();
        }

        public ICompany find_company_named(string name)
        {
            return session
                .all<ICompany>()
                .SingleOrDefault(x => x.name.is_equal_to_ignoring_case(name));
        }

        public ICompany find_company_by(Guid id)
        {
            return session.all<ICompany>().SingleOrDefault(x => x.id.Equals(id));
        }

        public void save(ICompany company)
        {
            session.save(company);
        }
    }
}