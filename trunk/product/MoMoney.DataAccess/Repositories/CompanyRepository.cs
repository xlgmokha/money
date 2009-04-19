using System;
using System.Collections.Generic;
using System.Linq;
using Gorilla.Commons.Infrastructure.Transactions;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Domain.accounting.billing;
using MoMoney.Domain.repositories;

namespace MoMoney.DataAccess.repositories
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