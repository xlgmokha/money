using System.Collections.Generic;
using System.ServiceModel;
using Gorilla.Commons.Utility.Core;
using MoMoney.DTO;

namespace MoMoney.Service.Application
{
    [ServiceContract]
    public interface IGetAllBillsQuery : IQuery<IEnumerable<BillInformationDTO>>
    {
    }
}