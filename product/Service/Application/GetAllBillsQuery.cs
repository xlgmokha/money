using System.Collections.Generic;
using gorilla.commons.utility;
using MoMoney.Domain.Accounting;
using MoMoney.Domain.repositories;
using MoMoney.DTO;
using MoMoney.Service.Contracts.Application;

namespace MoMoney.Service.Application
{
    public class GetAllBillsQuery : IGetAllBillsQuery
    {
        readonly IBillRepository bills;
        readonly Mapper<IBill, BillInformationDTO> mapper;

        public GetAllBillsQuery(IBillRepository bills, Mapper<IBill, BillInformationDTO> mapper)
        {
            this.bills = bills;
            this.mapper = mapper;
        }

        public IEnumerable<BillInformationDTO> fetch()
        {
            return bills.all().map_all_using(mapper);
        }
    }
}