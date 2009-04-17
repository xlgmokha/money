using System.Collections.Generic;
using MoMoney.Domain.accounting.billing;
using MoMoney.Domain.repositories;

namespace MoMoney.Tasks.application
{
    public interface IBillingTasks
    {
        IEnumerable<IBill> all_bills();
        IEnumerable<ICompany> all_companys();
    }

    public class BillingTasks : IBillingTasks
    {
        readonly IBillRepository bills;
        readonly ICompanyRepository companys;

        public BillingTasks(IBillRepository bills, ICompanyRepository companys)
        {
            this.bills = bills;
            this.companys = companys;
        }

        public IEnumerable<IBill> all_bills()
        {
            return bills.all();
        }

        public IEnumerable<ICompany> all_companys()
        {
            return companys.all();
        }
    }
}