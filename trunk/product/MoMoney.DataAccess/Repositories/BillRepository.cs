using System.Collections.Generic;
using MoMoney.DataAccess.core;
using MoMoney.Domain.accounting.billing;
using MoMoney.Domain.repositories;

namespace MoMoney.DataAccess.repositories
{
    public class BillRepository : IBillRepository
    {
        readonly IDatabaseGateway gateway;

        public BillRepository(IDatabaseGateway gateway)
        {
            this.gateway = gateway;
        }

        public IEnumerable<IBill> all()
        {
            return gateway.all<IBill>();
        }
    }
}