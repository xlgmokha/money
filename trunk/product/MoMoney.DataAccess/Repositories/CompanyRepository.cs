using System;
using System.Collections.Generic;
using System.Linq;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.DataAccess.core;
using MoMoney.Domain.accounting.billing;
using MoMoney.Domain.repositories;

namespace MoMoney.DataAccess.repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        readonly IDatabaseGateway gateway;

        public CompanyRepository(IDatabaseGateway gateway)
        {
            this.gateway = gateway;
        }

        public IEnumerable<ICompany> all()
        {
            return gateway.all<ICompany>();
        }

        public ICompany find_company_named(string name)
        {
            return gateway
                .all<ICompany>()
                .SingleOrDefault(x => x.name.is_equal_to_ignoring_case(name));
        }

        public ICompany find_company_by(Guid id)
        {
            return gateway.all<ICompany>().SingleOrDefault(x => x.id.Equals(id));
        }

        public void save(ICompany company)
        {
            gateway.save(company);
        }
    }
}