using System.Collections.Generic;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Domain.Accounting;
using MoMoney.Domain.repositories;
using MoMoney.DTO;

namespace MoMoney.Service.Application
{
    public class GetAllBillsQuery : IGetAllBillsQuery
    {
        readonly IBillRepository bills;
        readonly IMapper<IBill, BillInformationDTO> mapper;

        public GetAllBillsQuery(IBillRepository bills, IMapper<IBill, BillInformationDTO> mapper)
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