using System;
using System.Collections.Generic;
using System.Linq;
using gorilla.commons.utility;
using momoney.database.transactions;
//using MoMoney.Domain.Accounting;
//using MoMoney.Domain.repositories;

namespace momoney.database.repositories
{
    //public class CompanyRepository : ICompanyRepository
    //{
    //    readonly ISession session;

    //    public CompanyRepository(ISession session)
    //    {
    //        this.session = session;
    //    }

    //    public IEnumerable<Company> all()
    //    {
    //        return session.all<Company>();
    //    }

    //    public Company find_company_named(string name)
    //    {
    //        return all().SingleOrDefault(x => x.name.is_equal_to_ignoring_case(name));
    //    }

    //    public Company find_company_by(Guid id)
    //    {
    //        return all().SingleOrDefault(x => x.id.Equals(id));
    //    }

    //    public void save(Company company)
    //    {
    //        session.save(company);
    //    }
    //}
}