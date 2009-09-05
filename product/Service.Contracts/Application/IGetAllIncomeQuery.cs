using System.Collections.Generic;
using System.ServiceModel;
using Gorilla.Commons.Utility.Core;
using MoMoney.DTO;

namespace MoMoney.Service.Contracts.Application
{
    [ServiceContract]
    public interface IGetAllIncomeQuery : IQuery<IEnumerable<IncomeInformationDTO>>
    {
    }
}