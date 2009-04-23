using System.Collections.Generic;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Domain.accounting.billing;
using MoMoney.Domain.repositories;
using MoMoney.DTO;

namespace MoMoney.Service.Application
{
    public class GetAllBillsQuery : IGetAllBillsQuery
    {
        readonly IBillRepository bills;

        public GetAllBillsQuery(IBillRepository bills)
        {
            this.bills = bills;
        }

        public IEnumerable<BillInformationDTO> fetch()
        {
            return bills.all().map_all_using(x => map_from(x));
        }

        BillInformationDTO map_from(IBill bill)
        {
            return new BillInformationDTO
                       {
                           company_name = bill.company_to_pay.name,
                           the_amount_owed = bill.the_amount_owed.ToString(),
                           due_date = bill.due_date.to_date_time(),
                       };
        }
    }
}