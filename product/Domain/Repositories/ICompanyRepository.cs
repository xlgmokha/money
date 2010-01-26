using System;
using System.Collections.Generic;
using MoMoney.Domain.Accounting;

namespace MoMoney.Domain.repositories
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> all();
        Company find_company_named(string name);
        Company find_company_by(Guid id);
        void save(Company company);
    }
}