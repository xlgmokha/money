using System;
using System.Collections.Generic;
using MoMoney.Domain.Accounting;

namespace MoMoney.Domain.repositories
{
    public interface ICompanyRepository
    {
        IEnumerable<ICompany> all();
        ICompany find_company_named(string name);
        ICompany find_company_by(Guid id);
        void save(ICompany company);
    }
}