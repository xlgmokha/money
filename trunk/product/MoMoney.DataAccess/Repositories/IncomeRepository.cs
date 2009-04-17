using System.Collections.Generic;
using MoMoney.DataAccess.core;
using MoMoney.Domain.accounting.financial_growth;
using MoMoney.Domain.repositories;

namespace MoMoney.DataAccess.repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        readonly IDatabaseGateway gateway;

        public IncomeRepository(IDatabaseGateway gateway)
        {
            this.gateway = gateway;
        }

        public IEnumerable<IIncome> all()
        {
            return gateway.all<IIncome>();
        }
    }
}